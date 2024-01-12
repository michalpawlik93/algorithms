using BenchmarkDotNet.Attributes;
using DataStructures.Structures.Queue;
using System.Collections.Generic;

namespace DataStructures.Benchmark;

[MemoryDiagnoser]
public class StackBenchmark
{
    private const int Capacity = 50;
    public CustomStack<int> TestCustom { get; set; }
    public Stack<int> TestLib { get; set; }

    public StackBenchmark()
    {
        PopulateData();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        PopulateData();
    }

    [Benchmark(Baseline = true)]
    public void PushCustomStack()
    {
        TestCustom.Enqueue(7);
    }

    [Benchmark]
    public void PushStack()
    {
        TestLib.Push(7);
    }

    [Benchmark]
    public void PopCustomStack()
    {
        TestCustom.Dequeue();
    }

    [Benchmark]
    public void PopStack()
    {
        TestLib.Pop();
    }

    private void PopulateData()
    {
        TestCustom = new(Capacity);
        TestLib = new(Capacity);
        for (int i = 0; i < 6; i++)
        {
            TestCustom.Enqueue(i);
            TestLib.Push(i);
        }
    }
}
