/*Write a program to swap odd and even bits in a integer with a few instructions as possible (e.g., bit 0 and bit 1 are swapped , bit 2 and bit 3 ar swappend, and so on) */

use crate::utils::console_utils;

pub fn swap_odd_even_bits() {
    let input_n = console_utils::read_input();
    let n = console_utils::convert_binary_string_to_i32(input_n);

    println!(
        "Swapped number: {:032b}",
        swap_odd_even_bits_intern(n as u32)
    )
}

pub fn swap_odd_even_bits_intern(n: u32) -> u32 {
    const EVEN_MASK: u32 = 0xAAAAAAAA;
    const ODD_MASK: u32 = 0x55555555;

    let even_bits_shifted = (n & EVEN_MASK) >> 1;

    let odd_bits_shifted = (n & ODD_MASK) << 1;

    even_bits_shifted | odd_bits_shifted
}

#[cfg(test)]
mod exercise_6_tests {
    use super::*;

    #[test]
    fn test_swap_odd_even_bits_intern_1() {
        //Arrange
        let n = 0b010;
        //Act
        let result = swap_odd_even_bits_intern(n);
        //Assert
        assert_eq!(result, 0b001);
    }

    #[test]
    fn test_swap_odd_even_bits_intern_2() {
        //Arrange
        let n = 0b0101;
        //Act
        let result = swap_odd_even_bits_intern(n);
        //Assert
        assert_eq!(result, 0b1010);
    }
}
