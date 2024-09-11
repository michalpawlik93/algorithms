use std::ffi::c_void;
use std::mem::transmute;
use std::process;
use windows::Win32::Foundation::{CloseHandle, GetLastError, HANDLE, WAIT_TIMEOUT};
use windows::Win32::System::Diagnostics::Debug::WriteProcessMemory;
use windows::Win32::System::Memory::{
    VirtualAllocEx, MEM_COMMIT, MEM_RESERVE, PAGE_EXECUTE_READWRITE,
};
use windows::Win32::System::Threading::{
    CreateRemoteThread, OpenProcess, WaitForSingleObject, PROCESS_VM_OPERATION, PROCESS_VM_READ,
    PROCESS_VM_WRITE,
};

fn main() {
    let target_process_id = process::id();
    println!("My pid is {}", target_process_id);

    let h_process = unsafe {
        OpenProcess(
            PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ,
            false,
            target_process_id,
        )
    };

    match h_process {
        Ok(h_process) => {
            eprintln!("Process opened");

            let alloc_mem_address = unsafe {
                VirtualAllocEx(
                    h_process,
                    None,
                    1024,
                    MEM_COMMIT | MEM_RESERVE,
                    PAGE_EXECUTE_READWRITE,
                )
            };
            if alloc_mem_address.is_null() {
                eprintln!("Cannot allocate memory. Error: {:?}", unsafe {
                    GetLastError()
                });
                return;
            }

            // allocating data doesnt work... I got (exit code: 0xc0000005, STATUS_ACCESS_VIOLATION) allocating memory
            let shellcode: [u8; 3] = [
                // Allocate memory using VirtualAlloc
                0x6a, 0x00, // push 0 (lpAddress)
                0xc3, // RET (Return)
            ];

            let mut bytes_written: usize = 0;
            let write_result = unsafe {
                WriteProcessMemory(
                    h_process,
                    alloc_mem_address,
                    shellcode.as_ptr() as *const c_void,
                    shellcode.len(),
                    Some(&mut bytes_written as *mut usize),
                )
            };

            if write_result.is_err() {
                eprintln!("Failed to write to memory. Error: {:?}", unsafe {
                    GetLastError()
                });
                return;
            }

            eprintln!("Bytes written: {:?}", bytes_written);

            let thread_entry_point = unsafe {
                transmute::<*mut c_void, extern "system" fn(*mut c_void) -> u32>(alloc_mem_address)
            };

            let mut thread_id: u32 = 0;
            let h_thread = unsafe {
                CreateRemoteThread(
                    h_process,
                    None,
                    0,
                    Some(thread_entry_point),
                    None,
                    0,
                    Some(&mut thread_id),
                )
            };

            match h_thread {
                Ok(h_thread) => {
                    if h_thread.is_invalid() {
                        eprintln!("Cannot create thread. Error: {:?}", unsafe {
                            GetLastError()
                        });
                        return;
                    }

                    let wait_result = unsafe { WaitForSingleObject(h_thread, 5000) };

                    println!("Shellcode injected and remote thread created successfully.");

                    match wait_result {
                        WAIT_TIMEOUT => eprintln!("Thread timed out."),
                        _ => println!("Thread finished."),
                    }

                    unsafe {
                        CloseHandle(h_thread);
                    }
                }
                Err(err) => {
                    eprintln!("Failed to create remote thread. Error: {:?}", err);
                }
            }
        }
        Err(err) => eprintln!("Cannot open process. Error: {:?}", err),
    }
}
