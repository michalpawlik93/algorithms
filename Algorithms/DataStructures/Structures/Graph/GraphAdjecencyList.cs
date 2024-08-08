using DataStructures.Exercises.Graph;
using System;
using System.Collections.Generic;

namespace DataStructures.Structures.Graph;

public class GraphAdjecencyList
{
    public Dictionary<VertexStruct, List<VertexStruct>> Graph { get; private set; }

    public GraphAdjecencyList()
    {
        Graph = new();
    }

    public void Add(VertexStruct vertex, List<VertexStruct> connectedVertices)
    {
        if (Graph.ContainsKey(vertex))
        {
            Graph.AddVertices(vertex, connectedVertices);
        }
        else
        {
            Graph.Add(vertex, new List<VertexStruct>());
            Graph.AddVertices(vertex, connectedVertices);
        }
    }

    public void DisplayInConsole()
    {
        foreach (var vertex in Graph)
        {
            Console.WriteLine($"Vertex {vertex.Key.Id}: ");
            foreach (var connectedVertex in vertex.Value)
            {
                Console.WriteLine($"  - {connectedVertex.Id}");
            }
        }
    }
}

public record VertexLevel(int Level, VertexStruct Vertex);

public static class GraphExtensions
{
    public static void AddVertices(
        this Dictionary<VertexStruct, List<VertexStruct>> graph,
        VertexStruct vertex,
        List<VertexStruct> vertices
    )
    {
        foreach (var v in vertices)
        {
            if (!graph[vertex].Contains(v))
            {
                graph[vertex].Add(v);
            }
        }
    }
}

public struct VertexStruct : IEquatable<VertexStruct>
{
    public static VertexStruct Create(int id)
    {
        return new VertexStruct(id);
    }

    private VertexStruct(int id)
    {
        Id = id;
    }

    public int Id { get; }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object obj) => obj is VertexStruct other && Equals(other);

    public bool Equals(VertexStruct other) => other.Id == Id;
}

internal static class GraphAdjecencyListTestProgram
{
    private static GraphAdjecencyList CreateGraph()
    {
        var graph = new GraphAdjecencyList();
        var v1 = VertexStruct.Create(1);
        var v2 = VertexStruct.Create(2);
        var v3 = VertexStruct.Create(3);
        var v4 = VertexStruct.Create(4);
        graph.Add(v1, new List<VertexStruct>() { v2 });
        graph.Add(v2, new List<VertexStruct>() { v1, v3 });
        graph.Add(v3, new List<VertexStruct>() { v2, v4 });
        graph.Add(v4, new List<VertexStruct>());
        return graph;
    }

    public static void Run_DisplayAllVertices()
    {
        var graph = CreateGraph();
        graph.DisplayInConsole();
    }

    public static void Run_BfsFindLevelOfNode()
    {
        var graph = CreateGraph();
        var searchNode = VertexStruct.Create(4);
        var sourceNode = VertexStruct.Create(4);
        Console.WriteLine(
            $"Found level: {graph.Graph.BfsFindLevelOfNode(searchNode, sourceNode)} for root node:{sourceNode.Id} and searched node:{searchNode.Id}"
        );
    }

    public static void Run_DfTryFindWay()
    {
        var graph = new GraphAdjecencyList();
        var v1 = VertexStruct.Create(1);
        var v2 = VertexStruct.Create(2);
        var v3 = VertexStruct.Create(3);
        var v4 = VertexStruct.Create(4);
        graph.Add(v1, new List<VertexStruct>() { v2 });
        graph.Add(v2, new List<VertexStruct>() { v1, v3 });
        graph.Add(v3, new List<VertexStruct>() { v4 });
        graph.Add(v4, new List<VertexStruct>());
        Console.WriteLine(
            $"The way was found: {graph.Graph.DfTryFindWayRecursive(v1, v4)}, for root node:{v3.Id} and desitnation node:{v1.Id}"
        );
    }
}
