use std::io;
use std::str::FromStr;

pub fn read_input() -> String {
    let mut input_line = String::new();
    io::stdin()
        .read_line(&mut input_line)
        .expect("Failed to read the line");
    input_line
}

pub fn convert_to_number<T>(input_line: String) -> T
where
    T: FromStr,
    T::Err: std::fmt::Debug,
{
    match input_line.trim().parse::<T>() {
        Ok(num) => num,
        Err(_) => {
            eprintln!(
                "Input not a valid number for type {}",
                std::any::type_name::<T>()
            );
            std::process::exit(1);
        }
    }
}

pub fn convert_binary_string_to_i32(input_line: String) -> i32 {
    let input_line = input_line.trim();
    match i32::from_str_radix(input_line, 2) {
        Ok(num) => num,
        Err(_) => {
            eprintln!("Input is not a valid binary representation for i32");
            std::process::exit(1);
        }
    }
}
