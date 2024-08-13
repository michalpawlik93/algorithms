mod exercises;
mod utils;
fn main() {
    println!("Chose exercise by number");
    let number_input = utils::console_utils::read_input();
    let exercise_number: i8 = utils::console_utils::convert_to_number(number_input);
    match exercise_number {
        1 => exercises::exercise1::insert_integers(),
        2 => exercises::exercise2::binary_to_string(),
        3 => exercises::exercise3::find_longest_sequence(),
        _ => println!("Choosen no exercise"),
    }
}
