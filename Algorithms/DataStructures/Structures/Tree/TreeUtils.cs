using System;
using System.Collections.Generic;

namespace DataStructures.Structures.Tree;

public static class TreeUtils
{
    public static void DisplayTreeBfs(this Node root)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<NodeWithLevel>();
        queue.Enqueue(new NodeWithLevel(root, 0));
        Console.WriteLine($"Root {root.Id}");
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null || visited.Contains(node.node.Id)) continue;

            visited.Add(node.node.Id);

            if (node.node.Left != null)
            {
                var leftChild = new NodeWithLevel(node.node.Left, node.level + 1);
                Console.WriteLine($"Parent {node.node.Id} Level {node.level}, Left: {node.node.Left.Id}");
                queue.Enqueue(leftChild);
            }

            if (node.node.Right != null)
            {
                var rightChild = new NodeWithLevel(node.node.Right, node.level + 1);
                Console.WriteLine($"Parent {node.node.Id} Level {node.level}, Right: {node.node.Right.Id}");
                queue.Enqueue(rightChild);
            }
        }
    }

    private sealed record NodeWithLevel(Node node, int level);

    public sealed class Node
    {
        public Node(int id)
        {
            Id = id;
        }
        public int Id, Height = 0;
        public Node Left, Right;
    }
}
