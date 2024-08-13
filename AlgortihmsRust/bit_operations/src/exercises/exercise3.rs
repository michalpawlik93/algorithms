/*
You have an integer and you can flip one bit from a 0 to 1. Write code to find the length of the longest sequence of 1s you could create */

use crate::utils::bit_utils;
use crate::utils::console_utils;

pub fn find_longest_sequence() {
    println!("Enter a binary representation of number N:");
    let input_n = console_utils::read_input();
    let number = console_utils::convert_binary_string_to_i32(input_n);
    let combinations = get_all_combinations(number);

    for combo in &combinations {
        println!("{:b}", combo);
    }

    let max_comb = find_longest_sequence_intern(&combinations);
    println!(
        "Combination with the longest sequence of 1s: {:b}",
        max_comb
    );
}

fn get_all_combinations(number: i32) -> Vec<i32> {
    let mut combinations = Vec::new();
    let mut bit_position: i32 = 0;
    let mut current_number: i32 = number;

    while current_number != 0 {
        if current_number & 1 == 0 {
            // Add the original number with flipped bit
            let temp = bit_utils::set_bit(number, bit_position);
            combinations.push(temp);
        }
        current_number >>= 1;
        bit_position += 1;
    }

    // Ensure to add the original number itself if it has no zero bits
    if number.count_ones() == (32 - number.leading_zeros()) as u32 {
        combinations.push(number);
    }

    combinations
}

fn find_longest_sequence_intern(combinations: &[i32]) -> i32 {
    let mut max_length: i32 = 0;
    let mut max_comb: i32 = 0;

    for &comb in combinations {
        let mut comb_copy = comb;
        let mut current_length: i32 = 0;
        let mut current_max_length: i32 = 0;

        while comb_copy != 0 {
            if comb_copy & 1 == 1 {
                current_length += 1;
            } else {
                if current_length > current_max_length {
                    current_max_length = current_length;
                }
                current_length = 0;
            }
            comb_copy >>= 1;
        }

        if current_length > current_max_length {
            current_max_length = current_length;
        }

        if current_max_length > max_length {
            max_length = current_max_length;
            max_comb = comb;
        }
    }

    max_comb
}

#[cfg(test)]
mod exercise_3_tests {
    use super::*;

    #[test]
    fn test_find_longest_sequence_intern() {
        //Arrange
        let number = 0b1010;
        //Act
        let combinations = get_all_combinations(number);
        let result = find_longest_sequence_intern(&combinations);
        //Assert
        assert_eq!(result, 0b1110);
    }
}
