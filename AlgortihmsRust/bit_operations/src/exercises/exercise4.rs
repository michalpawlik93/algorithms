/*Given a positive integer , print the next smallest  and the enxt largest number that have the same number o 1 bits in their binary represenation */
use crate::utils::console_utils;
pub fn get_next_smaller_and_bigger() {
    println!("Executing get_next_smaller_and_bigger");
    let input_n = console_utils::read_input();
    let number = console_utils::convert_binary_string_to_i32(input_n);
    let one_count = count_one_number(number);
    let bigger = get_biggest_brute(number, one_count);
    let smaller = get_smallest_brute(number, one_count);
    println!("Next bigger number: {}", bigger);
    println!("Next smaller number: {}", smaller);
}
fn get_biggest_brute(number: i32, one_count: i32) -> i32 {
    let mut current: i32 = number + 1;
    while count_one_number(current) != one_count {
        current += 1;
    }
    current
}

fn get_smallest_brute(number: i32, one_count: i32) -> i32 {
    let mut current: i32 = number - 1;
    while count_one_number(current) != one_count {
        current -= 1;
    }
    current
}

fn count_one_number(mut number: i32) -> i32 {
    let mut counter = 0;
    while number != 0 {
        if number & 1 == 1 {
            counter += 1;
        }
        number >>= 1;
    }
    counter
}

#[allow(dead_code)]
fn get_next_bigger_by_bit_manipulation(mut number: i32) -> i32 {
    let mut c = number;
    let mut c0 = 0;
    let mut c1 = 0;

    // Count trailing zeros
    while (c & 1) == 0 && c != 0 {
        c0 += 1;
        c >>= 1;
    }

    // Count trailing ones
    while (c & 1) == 1 {
        c1 += 1;
        c >>= 1;
    }
    // Edge case: if all 1s or no valid bigger number
    if c0 + c1 == 31 || c0 + c1 == 0 {
        println!("There is no bigger number with the same number of 1s.");
        return -1;
    }

    // Step 2: Position of the rightmost non-trailing zero
    let p = c0 + c1;

    // Step 3: Flip the rightmost non-trailing zero
    number |= 1 << p;

    // Step 4: Clear all the bits to the right of position p
    number &= !((1 << p) - 1);

    // Step 5: Insert c1 - 1 ones on the right
    number |= (1 << (c1 - 1)) - 1;

    number
}

#[cfg(test)]
mod exercise_4_tests {
    use super::*;

    #[test]
    fn test_count_one_number() {
        //Arrange
        let number = 0b101011;
        //Act
        let result = count_one_number(number);
        //Assert
        assert_eq!(result, 4);
    }

    #[test]
    fn test_get_biggest_brute() {
        //Arrange
        let number = 0b10101;
        //Act
        let result = get_biggest_brute(number, 3);
        //Assert
        assert_eq!(result, 22);
    }
    #[test]
    fn test_get_smallest_brute() {
        //Arrange
        let number = 0b10101;
        //Act
        let result = get_smallest_brute(number, 3);
        //Assert
        assert_eq!(result, 19);
    }

    #[test]
    fn test_get_next_bigger_by_bit_manipulation() {
        //Arrange
        let number = 0b10101;
        //Act
        let result = get_next_bigger_by_bit_manipulation(number);
        //Assert
        assert_eq!(result, 22);
    }
}
