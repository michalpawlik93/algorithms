// See https://aka.ms/new-console-template for more information


//var list = new CustomLinkedList<int>();
//var targetGuid = Guid.NewGuid();
//list.InsertFirst(3).InsertFirst(2, targetGuid).InsertFirst(1);

//list.InsertLast(4).InsertLast(5).InsertLast(6);

//list.InsertAfter(new Node<int>(2, targetGuid), 6);
//foreach (var item in list)
//{
//    Console.WriteLine(item);
//}


using BenchmarkDotNet.Running;
using DataStructures.Benchmark;

BenchmarkRunner.Run<LinkedListBenchmark>();