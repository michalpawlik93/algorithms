using Algorithms.Sort.Algorithms;
using BenchmarkDotNet.Attributes;
using Collections.Benchmark.Fixtures;

namespace Algorithms.Sort.Benchmark;

[MemoryDiagnoser]
public class CompareSortAlgorithmsBenchmark
{
    [ParamsSource(nameof(ValuesForArrayLength))]
    public int ArrayLength { get; set; }
    public Dictionary<int, char[]>[] TestArray { get; set; }

    public IEnumerable<int> ValuesForArrayLength =>
        new[] { ArrayFixtures.Length30, ArrayFixtures.Length300, ArrayFixtures.Length1000 };

    public CompareSortAlgorithmsBenchmark()
    {
        TestArray = new Dictionary<int, char[]>[]
        {
            ArrayFixtures.GenerateTestData,
            ArrayFixtures.GenerateTestData,
            ArrayFixtures.GenerateTestData
        };
    }

    [Benchmark(Baseline = true)]
    public void BubbleSort()
    {
        TestArray[0][ArrayLength].SortAdaptiveBubble();
    }

    [Benchmark]
    public void MergeSort()
    {
        TestArray[1][ArrayLength].SortMerge();
    }

    [Benchmark]
    public void QuickSort()
    {
        TestArray[2][ArrayLength].SortQuick();
    }
}
