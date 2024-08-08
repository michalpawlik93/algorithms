mod utils;
fn main() {
    let x: i8 = 5;
    let bit_position: i8 = 4;
    let result = utils::bit_utils::set_bit(x, bit_position);
    println!("Result is: {}", result);
    println!("Result after setting bit (binary): {:08b}", result);
}
