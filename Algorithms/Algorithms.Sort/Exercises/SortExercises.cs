using Algorithms.Sort.Algorithms;
using Collections.Arrays;
using Collections.Benchmark.Fixtures;

namespace Algorithms.Sort.Exercises;

public static class SortExercises
{
    public static void TestMergeSort()
    {
        var array = ArrayFixtures.GenerateRandomArray(20);
        var result = MergeSort.SortMergeWithSpan(array);
        ArrayUtils.DisplayAllArrayElements(result);
    }

    public static void TestBubbleSort()
    {
        var array = ArrayFixtures.GenerateRandomArray(20);
        var result = BubbleSort.SortBubble(array);
        ArrayUtils.DisplayAllArrayElements(result);
    }

    public static void TestQuickSort()
    {
        var array = ArrayFixtures.GenerateRandomArray(20);
        var result = QuickSort.SortQuick(array);
        ArrayUtils.DisplayAllArrayElements(result);
    }

    public static void GroupAnagrams()
    {
        var anagrams = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        foreach (var anagram in anagrams.SortBucketOnBuildInStructures())
        {
            Console.WriteLine(anagram);
        }
    }
}
