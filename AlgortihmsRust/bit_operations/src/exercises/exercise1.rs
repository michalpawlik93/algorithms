// You are given 32 bit numbers, N and M, and two bit positions, i and j.
// Write a method to isnert M into N such that M starts ad bit j and edns at bit i.

// Example N=10000000000, M=10011, i=2, i=6
//Output N=10001001100
fn insert_integers(n: i32, m: i32, i: i32, j: i32) -> i32 {
    if (n > m || i < 0 || j >= 32) {
        return 0;
    }
    // Clear bits i through j in N
}
