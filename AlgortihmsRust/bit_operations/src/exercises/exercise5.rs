/*
Write a function to determine the number of bits you would need to flip to convert integer A to integer B */

use crate::utils::console_utils;

pub fn count_bits_to_convert_int_to_int() {
    let input_n1 = console_utils::read_input();
    let n1 = console_utils::convert_binary_string_to_i32(input_n1);
    let input_n2 = console_utils::read_input();
    let n2 = console_utils::convert_binary_string_to_i32(input_n2);

    println!(
        "{} required",
        count_bits_to_convert_int_to_int_intern(n1, n2)
    )
}

fn count_bits_to_convert_int_to_int_intern(mut n1: i32, mut n2: i32) -> i32 {
    let mut bits_to_flip = 0;
    while n1 != 0 || n2 != 0 {
        if (n1 & 1) != (n2 & 1) {
            bits_to_flip += 1;
        }
        n1 >>= 1;
        n2 >>= 1;
    }
    bits_to_flip
}

#[cfg(test)]
mod exercise_5_tests {
    use super::*;

    #[test]
    fn test_count_bits_to_convert_int_to_int_intern() {
        //Arrange
        let n1 = 0b10101; // 21 in decimal
        let n2 = 0b11111; // 31 in decimal
                          //Act
        let result = count_bits_to_convert_int_to_int_intern(n1, n2);
        //Assert
        assert_eq!(result, 2);
    }
}
