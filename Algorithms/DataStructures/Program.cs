//BenchmarkRunner.Run<LinkedListBenchmark>();
//BenchmarkRunner.Run<DictionaryBenchmark>();
//BenchmarkRunner.Run<QueueBenchmark>();
//BenchmarkRunner.Run<StackBenchmark>();



//GraphLinkedListTestProgram.Run_BfsFindLevelOfNode();
//GraphAdjecencyListTestProgram.Run_DfTryFindWay();
//GraphAdjacencyMatrixTestProgram.Run();

//Exercise1AVL.Run();

using System;
using System.Threading.Tasks;

var arr = new int[] { 2, 6, 1, 2, 5, 3 };
await MarekTea();
//buuble sort


async Task<string> MarekTea()
{
    var water = await BoilWater();
    Console.WriteLine("put tea in cup");
    var tea = $"pour {water} in coup";

    Console.WriteLine(tea);
    return tea;
}

async Task<string> BoilWater()
{
    Console.WriteLine("Start kettle");
    await Task.Delay(2000);
    Console.WriteLine("Kettle finished");
    return "water";
}

