using Algorithms.Sort.Algorithms;
using BenchmarkDotNet.Attributes;
using Collections.Arrays;
using Collections.Benchmark.Fixtures;

namespace Algorithms.Sort.Benchmark;

[MemoryDiagnoser]
public class MergeSortBenchmark
{
    [ParamsSource(nameof(ValuesForArrayLength))]
    public int ArrayLength { get; set; }
    public Dictionary<int, char[]> GeneratedTestData { get; set; }
    public Dictionary<int, char[]> IterationTestArray { get; set; }

    public IEnumerable<int> ValuesForArrayLength =>
        new[] { ArrayFixtures.Length30, ArrayFixtures.Length300, ArrayFixtures.Length1000 };

    public MergeSortBenchmark()
    {
        GeneratedTestData = ArrayFixtures.GenerateTestData;
        IterationTestArray = new Dictionary<int, char[]>();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        IterationTestArray = new Dictionary<int, char[]>();
        foreach (var item in GeneratedTestData)
        {
            IterationTestArray.Add(item.Key, item.Value.CopyToNewArray());
        }
    }

    [Benchmark(Baseline = true)]
    public void MergeSort()
    {
        IterationTestArray[ArrayLength].SortMerge();
    }

    [Benchmark]
    public void MergeSortWithSpan()
    {
        IterationTestArray[ArrayLength].SortMergeWithSpan();
    }
}
