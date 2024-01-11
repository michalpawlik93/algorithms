using BenchmarkDotNet.Attributes;
using DataStructures.Structures.LinkedList;
using System.Collections.Generic;

namespace DataStructures.Benchmark;

[MemoryDiagnoser]
public class LinkedListBenchmark
{
    public CustomLinkedList<int> TestCustomLinkedList { get; set; }
    public LinkedList<int> TestLinkedList { get; set; }

    public LinkedListBenchmark()
    {
        PopulateData();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        PopulateData();
    }

    [Benchmark(Baseline = true)]
    public void InsertLastCustomList()
    {
        TestCustomLinkedList.InsertLast(4);
    }

    [Benchmark]
    public void InsertLastLinkedList()
    {
        TestLinkedList.AddLast(4);
    }

    [Benchmark]
    public void InsertFirstCustomList()
    {
        TestCustomLinkedList.InsertFirst(4);
    }

    [Benchmark]
    public void InsertFirstLinkedList()
    {
        TestLinkedList.AddFirst(4);
    }

    private void PopulateData()
    {
        TestCustomLinkedList = new();
        TestCustomLinkedList.InsertLast(0);
        TestCustomLinkedList.InsertLast(1);
        TestCustomLinkedList.InsertLast(2);
        TestCustomLinkedList.InsertLast(3);
        TestLinkedList = new();
        TestLinkedList.AddLast(0);
        TestLinkedList.AddLast(1);
        TestLinkedList.AddLast(2);
        TestLinkedList.AddLast(3);
    }
}
