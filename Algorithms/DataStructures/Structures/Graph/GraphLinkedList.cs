using System;
using System.Collections.Generic;

namespace DataStructures.Structures.Graph;

public class GraphLinkedList
{
    private readonly Dictionary<VertexStruct, LinkedList<VertexStruct>> Graph;

    public GraphLinkedList()
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
            Graph.Add(vertex, new LinkedList<VertexStruct>());
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

public static class GraphExtensions
{
    public static void AddVertices(
        this Dictionary<VertexStruct, LinkedList<VertexStruct>> graph,
        VertexStruct vertex,
        List<VertexStruct> vertices
    )
    {
        foreach (var v in vertices)
        {
            if (!graph[vertex].Contains(v))
            {
                graph[vertex].AddLast(v);
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



internal static class GraphLinkedListTestProgram
{
    public static void Run()
    {
        var graph = new GraphLinkedList();
        var v1 = VertexStruct.Create(1);
        var v2 = VertexStruct.Create(2);
        var v3 = VertexStruct.Create(3);
        var v4 = VertexStruct.Create(4);
        graph.Add(v1, new List<VertexStruct>() { v2, v3 });
        graph.Add(v2, new List<VertexStruct>() { v1, v3 });
        graph.Add(v3, new List<VertexStruct>() { v1, v2 });
        graph.Add(v4, new List<VertexStruct>() { v1, v2 });
        graph.DisplayInConsole();
    }
}