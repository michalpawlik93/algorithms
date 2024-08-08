using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Exercises.Graph;

/// <summary>
/// Given a sorted array with unique ints, write algorithm to create binary search tree with minimal height
/// </summary>
public static class Exercise3
{
    public static void Run()
    {
        var input = new int[] { 1, 2, 3 };
        var root = CreateBinarySearchTreeInOrderMethode(input);
        var root2 = ToBalancedTree(input);
        DisplayTreeDepthFirst(root);
        Console.WriteLine("---");
        DisplayTreeBfs(root);
    }
    #region ToBalancedTree
    private static Node ToBalancedTree(int[] sortedArray)
    {
        return DivideAndConquer(sortedArray.Select(x => new Node(x)).ToArray(), 0, sortedArray.Length - 1);
    }

    private static Node DivideAndConquer(Node[] nodes, int start, int end)
    {
        if (start > end)
        {
            return null;
        }
        var mid = (start + end) / 2;
        var currentNode = nodes[mid];
        currentNode.Left = DivideAndConquer(nodes, start, mid - 1);
        currentNode.Right = DivideAndConquer(nodes, mid + 1, end);
        return currentNode;
    }

    #endregion
    #region InOrderUnbalanced

    /// <summary>
    /// Complexity n Log n, no minimal height, unbalced tree
    /// </summary>
    /// <param name="sortedArray"></param>
    /// <returns></returns>
    private static Node CreateBinarySearchTreeInOrderMethode(int[] sortedArray)
    {
        if (sortedArray.Length == 0) return null;
        var middle = sortedArray.Length / 2;
        var root = new Node(sortedArray[middle]);
        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (i == middle)
            {
                continue;
            }
            InsertNode(root, sortedArray[i]);
        }
        return root;
    }

    private static Node InsertNode(Node node, int newKey)
    {
        if (node is null)
        {
            return new Node(newKey);
        }
        if (newKey > node.Id)
        {
            node.Right = InsertNode(node.Right, newKey);
        }
        else if (newKey < node.Id)
        {
            node.Left = InsertNode(node.Left, newKey);
        }
        return node;
    }

    # endregion

    private sealed class Node
    {
        public Node(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    #region DisplayUtils
    static void DisplayTreeDepthFirst(Node root)
    {
        DisplayNode(root, 0);
    }

    static void DisplayTreeBfs(Node root)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<NodeWithLevel>();
        queue.Enqueue(new NodeWithLevel(root, 0));
        Console.WriteLine($"Root {root.Id}");
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null || visited.Contains(node.node.Id)) return;
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

    private static Node DisplayNode(Node node, int level)
    {
        if (node == null) return null;
        var left = DisplayNode(node.Left, level + 1);
        var right = DisplayNode(node.Right, level + 1);
        if (left != null)
        {
            Console.WriteLine($"Level {level}: {left.Id}");
        }
        if (right != null)
        {
            Console.WriteLine($"Level {level}: {right.Id}");
        }
        return node;
    }
    #endregion
}
