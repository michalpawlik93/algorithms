using DataStructures.Structures.Graph;
using System.Collections.Generic;

namespace DataStructures.Exercises.Graph;

/// <summary>
/// Check if there is way from vertex one to vertex two
/// </summary>
public static class Exercise2
{
    public static bool DfTryFindWay(
        this Dictionary<VertexStruct, LinkedList<VertexStruct>> graph,
        VertexStruct sourceVertex,
        VertexStruct destVertex
    )
    {
        if (!graph.ContainsKey(destVertex) || !graph.ContainsKey(sourceVertex))
        {
            return false;
        }

        var visted = new HashSet<VertexStruct>();
        var stack = new Stack<VertexStruct>();
        var result = false;

        stack.Push(sourceVertex);

        while (stack.Count > 0)
        {
            var v = stack.Pop();

            if (destVertex.Equals(v))
            {
                result = true;
                break;
            }
            else
            {
                visted.Add(v);
            }

            foreach (var linkedV in graph[v])
            {
                if (!visted.Contains(linkedV))
                {
                    stack.Push(linkedV);
                }
            }
        }

        return result;
    }

    public static bool DfTryFindWayRecursive(
        this Dictionary<VertexStruct, List<VertexStruct>> graph,
        VertexStruct sourceVertex,
        VertexStruct destVertex
    )
    {
        var visited = new HashSet<VertexStruct>();
        return DfRecursive(visited, graph, graph[sourceVertex], destVertex);
    }

    private static bool DfRecursive(
        HashSet<VertexStruct> visited,
        Dictionary<VertexStruct, List<VertexStruct>> graph,
        List<VertexStruct> adjacentVertices,
        VertexStruct destVertex
    )
    {
        var wayFound = false;
        foreach (var v in adjacentVertices)
        {
            if (visited.Contains(v))
            {
                continue;
            }
            visited.Add(v);

            if (destVertex.Equals(v) || DfRecursive(visited, graph, graph[v], destVertex))
            {
                wayFound = true;
                break;
            }
        }
        return wayFound;
    }
}
