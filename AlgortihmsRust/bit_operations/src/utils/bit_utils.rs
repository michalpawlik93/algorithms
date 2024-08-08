/*
n=5 (101), i = 2
Create bit mask with only one bit set to one: 1 << 2 = 100
Operation & returns one only if both bits are one.
At that moment bit in n on i position is detemined.
00000101
00000100
----
00000101
 */
pub fn get_bit(num: i8, i: i8) -> bool {
    return (num & (1 << i)) != 0;
}

/*
Operation | change value only if bit at desired position is 0.
For i = 2
00000101
00000100
----
00000101
 */
pub fn set_bit(num: i8, i: i8) -> i8 {
    return num | (1 << i);
}