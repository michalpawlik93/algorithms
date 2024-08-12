/*Binary to string: Given a real number between 0 and 1 that is pased in a double. Print the binary representation.
If the number can not be represented accurately in binary with at most 32 characters, print "Error"*/

use crate::utils::console_utils;

/* The pattern is to calculate and shift fractional part by one place. Multiple base 2 number by 2 in base 10. If first digit before decimal is
one then put one in bit result
r = (2 in base 10) * (input number in base 2)
r = (2 in base 10) * (0.101 in base 2) = 1.01 in base 2 = 1.01 in base 2
 */
pub fn binary_to_string() {
    let num = read_input_data();
    binary_to_string_intern(num);
}

fn binary_to_string_intern(num: f32) -> String {
    if num > 1.0 || num < 0.0 {
        return "Input must be between 0 and 1".to_string();
    }

    let mut binary = String::from("0.");
    let mut num = num;
    while num > 0.0 {
        if binary.len() >= 34 {
            return "ERROR".to_string();
        }

        num *= 2.0;
        if num >= 1.0 {
            binary.push('1');
            num -= 1.0;
        } else {
            binary.push('0');
        }
    }

    binary
}

fn read_input_data() -> f32 {
    println!("Enter a double number:");
    let input = console_utils::read_input();

    return console_utils::convert_to_number::<f32>(input);
}

#[cfg(test)]
mod exercise_2_tests {
    use super::*;

    #[test]
    fn test_binary_to_string() {
        let result = binary_to_string_intern(0.625);
        assert_eq!(result, "0.101");
    }
}
