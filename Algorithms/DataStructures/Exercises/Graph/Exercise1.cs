using DataStructures.Structures.Graph;
using System.Collections.Generic;

namespace DataStructures.Exercises.Graph;

/// <summary>
/// Find leve of given vertex
/// </summary>
public static class Exercise1
{
    private const int VertexNotFound = -1;
    public static int BfsFindLevelOfNode(this Dictionary<VertexStruct, List<VertexStruct>> graph, VertexStruct searchVertex, VertexStruct sourceVertex)
    {
        if (!graph.ContainsKey(searchVertex) || !graph.ContainsKey(sourceVertex))
        {
            return VertexNotFound;
        }


        int level = VertexNotFound;
        var visited = new HashSet<VertexStruct>();
        var queue = new Queue<VertexLevel>();
        queue.Enqueue(new VertexLevel(0, sourceVertex));

        while (queue.Count > 0)
        {
            var next = queue.Dequeue();
            if (next.Vertex.Equals(searchVertex))
            {
                level = next.Level;
                break;
            }
            if (graph.ContainsKey(next.Vertex))
            {
                foreach (var v in graph[next.Vertex])
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        queue.Enqueue(new VertexLevel(next.Level + 1, v));
                    }
                }
            }
        }
        return level;
    }
}
