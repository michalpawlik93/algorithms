using Algorithms.Sort.Algorithms;
using BenchmarkDotNet.Attributes;
using Collections.Benchmark.Fixtures;

namespace Algorithms.Sort.Benchmark;

[MemoryDiagnoser]
public class MergeSortBenchmark
{
    [ParamsSource(nameof(ValuesForArrayLength))]
    public int ArrayLength { get; set; }
    public Dictionary<int, char[]>[] TestArray { get; set; }

    public IEnumerable<int> ValuesForArrayLength =>
        new[] { ArrayFixtures.Length30, ArrayFixtures.Length300, ArrayFixtures.Length1000 };

    public MergeSortBenchmark()
    {
        TestArray = new Dictionary<int, char[]>[]
        {
            ArrayFixtures.GenerateTestData,
            ArrayFixtures.GenerateTestData,
        };
    }

    [Benchmark(Baseline = true)]
    public void MergeSort()
    {
        TestArray[0][ArrayLength].SortMerge();
    }

    [Benchmark]
    public void MergeSortWithSpan()
    {
        TestArray[1][ArrayLength].SortMergeWithSpan();
    }
}
