using Algorithms.Sort.Algorithms;
using BenchmarkDotNet.Attributes;
using Collections.Arrays;
using Collections.Benchmark.Fixtures;

namespace Algorithms.Sort.Benchmark;

[MemoryDiagnoser]
public class BubbleSortBenchmark
{
    [ParamsSource(nameof(ValuesForArrayLength))]
    public int ArrayLength { get; set; }
    public Dictionary<int, char[]> GeneratedTestData { get; set; }
    public Dictionary<int, char[]> IterationTestArray { get; set; }

    public IEnumerable<int> ValuesForArrayLength =>
        new[] { ArrayFixtures.Length30, ArrayFixtures.Length300, ArrayFixtures.Length1000 };

    public BubbleSortBenchmark()
    {
        GeneratedTestData = ArrayFixtures.GenerateTestData;
        IterationTestArray = new();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        IterationTestArray = new();
        foreach (var item in GeneratedTestData)
        {
            IterationTestArray.Add(item.Key, item.Value.CopyToNewArray());
        }
    }

    [Benchmark(Baseline = true)]
    public void BubbleSort()
    {
        IterationTestArray[ArrayLength].SortBubble();
    }

    [Benchmark]
    public void BubbleSortAdaptive()
    {
        IterationTestArray[ArrayLength].SortAdaptiveBubble();
    }

    [Benchmark]
    public void BubbleSortAdaptiveAsSpan()
    {
        IterationTestArray[ArrayLength].SortAdaptiveBubbleAsSpan();
    }
}
