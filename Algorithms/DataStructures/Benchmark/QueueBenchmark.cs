using BenchmarkDotNet.Attributes;
using DataStructures.Structures.Queue;
using System.Collections.Generic;

namespace DataStructures.Benchmark;

[MemoryDiagnoser]
public class QueueBenchmark
{
    private const int Capacity = 50;
    public CustomQueue<int> TestCustomQueue { get; set; }
    public Queue<int> TestQueue { get; set; }

    public QueueBenchmark()
    {
        PopulateData();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        PopulateData();
    }

    [Benchmark(Baseline = true)]
    public void EnqueueCustomQueue()
    {
        TestCustomQueue.Enqueue(7);
    }

    [Benchmark]
    public void EnqueueQueue()
    {
        TestQueue.Enqueue(7);
    }

    [Benchmark]
    public void DequeueCustomQueue()
    {
        TestCustomQueue.Dequeue();
    }

    [Benchmark]
    public void DequeueQueue()
    {
        TestQueue.Dequeue();
    }

    private void PopulateData()
    {
        TestCustomQueue = new(Capacity);
        TestQueue = new(Capacity);
        for (int i = 0; i < 6; i++)
        {
            TestCustomQueue.Enqueue(i);
            TestQueue.Enqueue(i);
        }
    }
}
