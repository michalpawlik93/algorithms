using Algorithms.Sort.Utils;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Sort.Benchmark.Utils;

[MemoryDiagnoser]
public class ArrayUtilsBenchmark
{
    [Benchmark(Baseline = true)]
    public void CopyArray()
    {
        var arr1 = new char[] { 'a', 'd', 'b' };
        var arr2 = new char[] { 'z', 'l', 'a', ' ' };
        ArrayUtils.CopyByArrayCopy(arr1, arr2);
    }

    [Benchmark]
    public void CopyArrayForeach()
    {
        var arr1 = new char[] { 'a', 'd', 'b' };
        var arr2 = new char[] { 'z', 'l', 'a', ' ' };
        ArrayUtils.CopyByForeach(arr1, arr2);
    }
}
