using BenchmarkDotNet.Attributes;
using DataStructures.Structures.Hashing;
using System.Collections.Generic;

namespace DataStructures.Benchmark;

[MemoryDiagnoser]
public class DictionaryBenchmark
{
    private const int Capacity = 50;
    public CustomDictionary<int> TestCustomDictionary { get; set; }
    public Dictionary<string, int> TestDictionary { get; set; }

    public DictionaryBenchmark()
    {
        PopulateData();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        PopulateData();
    }

    [Benchmark(Baseline = true)]
    public void GetItemCustomDictionary()
    {
        TestCustomDictionary.GetValue((Capacity / 2).ToString());
    }

    [Benchmark]
    public void GetItemDictionary()
    {
        TestDictionary.TryGetValue((Capacity / 2).ToString(), out int _);
    }

    private void PopulateData()
    {
        TestCustomDictionary = new();
        TestDictionary = new();
        for (int i = 0; i < Capacity; i++)
        {
            TestCustomDictionary.AddValue(i.ToString(), i);
            TestDictionary.Add(i.ToString(), i);
        }
    }
}
