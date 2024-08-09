use crate::utils::console_utils;

/*  You are given 32 bit numbers, N and M, and two bit positions, i and j.
    Write a method to insert M into N such that M starts at bit j and ends at bit i.
    Example N=10000000000, M=10011, i=2, j=6
    Output N=10001001100
*/

pub fn insert_integers() {
    println!("insert_integers exercise 1");
    let (input_n, input_m, input_bit_position_i, input_bit_position_j): (i32, i32, i8, i8) =
        read_input_data();
    let result: i32 =
        insert_integers_intern(input_n, input_m, input_bit_position_i, input_bit_position_j);
    println!("Result is: {}", result);
    println!("Result (binary): {:032b}", result); // Print as 32-bit binary
}

fn insert_integers_intern(n: i32, m: i32, i: i8, j: i8) -> i32 {
    if i < 0 || j >= 32 || i > j {
        eprintln!("Invalid bit positions.");
        std::process::exit(1);
    }

    let mask: i32 = !0;
    let left_mask: i32 = if j < 31 { mask << (j + 1) } else { 0 };
    let right_mask: i32 = mask >> (i + 1);
    let merged_mask = left_mask | right_mask;

    let n_cleared = n & merged_mask;
    let m_shifted = m << i;

    n_cleared | m_shifted
}

fn read_input_data() -> (i32, i32, i8, i8) {
    println!("Enter a binary representation of number N:");
    let input_n = console_utils::read_input();
    println!("Enter a binary representation of number M:");
    let input_m = console_utils::read_input();
    println!("Enter a bit position i:");
    let input_bit_position_i = console_utils::read_input();
    println!("Enter a bit position j:");
    let input_bit_position_j = console_utils::read_input();

    (
        console_utils::convert_binary_string_to_i32(input_n),
        console_utils::convert_binary_string_to_i32(input_m),
        console_utils::convert_to_int::<i8>(input_bit_position_i),
        console_utils::convert_to_int::<i8>(input_bit_position_j),
    )
}
