using Algorithms.Sort.Algorithms;
using Algorithms.Sort.Utils;

namespace Algorithms.Sort.Exercises;

/// <summary>
/// Array 1 ["a","d","b"], Array 2. ["z","l","a",""]
/// Array 1 must be merged with array 2 and sorted
/// </summary>
public static class Sort2CharArraysAsc
{
    public static void TestBubbleSort()
    {
        var result = BubbleSort.Sort(new char[] { 'a', 'd', 'b' }, new char[] { 'z', 'l', 'a', ' ' });
        ArrayUtils.DisplayAllArrayElements(result);
    }
}
