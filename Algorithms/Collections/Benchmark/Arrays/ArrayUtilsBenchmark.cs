using BenchmarkDotNet.Attributes;
using Collections.Arrays;
using Collections.Benchmark.Fixtures;

namespace Collections.Benchmark.Arrays;

[MemoryDiagnoser]
public class ArrayUtilsBenchmark
{
    [ParamsSource(nameof(ValuesForArrayLength))]
    public int ArrayLength { get; set; }
    public Dictionary<int, char[]> TestArray1 { get; set; }
    public Dictionary<int, char[]> TestArray2 { get; set; }

    public IEnumerable<int> ValuesForArrayLength =>
        new[] { ArrayFixtures.Length30, ArrayFixtures.Length300, ArrayFixtures.Length1000 };

    public ArrayUtilsBenchmark()
    {
        TestArray1 = ArrayFixtures.GenerateTestData;
        TestArray2 = ArrayFixtures.GenerateTestData;
    }

    [Benchmark(Baseline = true)]
    public void CopyArray()
    {
        ArrayUtils.CopyByArrayCopy(TestArray1[ArrayLength], TestArray2[ArrayLength]);
    }

    [Benchmark]
    public void CopyArrayForeach()
    {
        ArrayUtils.CopyByForeach(TestArray1[ArrayLength], TestArray2[ArrayLength]);
    }

    [Benchmark]
    public void CopyArrayFor()
    {
        ArrayUtils.CopyByFor(TestArray1[ArrayLength], TestArray2[ArrayLength]);
    }

    [Benchmark]
    public void CopyArrayConcat()
    {
        ArrayUtils.CopyByConat(TestArray1[ArrayLength], TestArray2[ArrayLength]);
    }
}
