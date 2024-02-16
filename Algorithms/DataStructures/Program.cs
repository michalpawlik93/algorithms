//BenchmarkRunner.Run<LinkedListBenchmark>();
//BenchmarkRunner.Run<DictionaryBenchmark>();
//BenchmarkRunner.Run<QueueBenchmark>();
//BenchmarkRunner.Run<StackBenchmark>();


using DataStructures.Structures.Graph;

var newG = new GraphAdjacencyMatrix();
for (int i = 1; i < 10; i++)
{
    newG.Add(new Vertex(i), new Vertex[0]);
}
newG.Add(new Vertex(10), new Vertex[] { new Vertex(2), new Vertex(3) });
newG.PrintMatrix();