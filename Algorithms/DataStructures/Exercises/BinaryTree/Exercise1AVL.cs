using System;
using static DataStructures.Structures.Tree.TreeUtils;

namespace DataStructures.Exercises.BinaryTree;

/// <summary>
/// Create AVL tree
/// </summary>
public static class Exercise1AVL
{
    public static void Run()
    {
        var root = new Node(5);
        InsertRecursive(root, new Node(3));
        InsertRecursive(root, new Node(7));
        InsertRecursive(root, new Node(2));
        InsertRecursive(root, new Node(1));
        InsertRecursive(root, new Node(9));
        root.DisplayTreeBfs();
    }

    private static Node InsertRecursive(Node current, Node newNode)
    {
        if (current is null)
        {
            current = newNode;
        }
        else if (newNode.Id > current.Id)
        {
            current.Right = InsertRecursive(current.Right, newNode);
        }
        else if (newNode.Id < current.Id)
        {
            current.Left = InsertRecursive(current.Left, newNode);
        }
        current = Balance(current); // Balance the current node
        current = UpdateHeight(current);
        return current;
    }

    private static Node DeleteRecursive(Node current, Node newNode)
    {
        if (current is null)
        {
            return null;
        }
        else if (newNode.Id > current.Id)
        {
            current.Right = InsertRecursive(current.Right, newNode);
        }
        else if (newNode.Id < current.Id)
        {
            current.Left = InsertRecursive(current.Left, newNode);
        }
        current = Balance(current); // Balance the current node
        current = UpdateHeight(current);
        return current;
    }

    private static Node Balance(Node current)
    {
        var balanceFactor = GetBalanceFactor(current);
        if (balanceFactor > 1) //left branch
        {
            if (GetBalanceFactor(current.Left) > 0)
            {
                current = RotateLeftLeftCase(current);
            }
            else
            {
                current = RotateLeftRightCase(current);
            }
        }
        else if (balanceFactor < -1) // right branch
        {
            if (GetBalanceFactor(current.Right) > 0)
            {
                current = RotateRightLeftCase(current);
            }
            else
            {
                current = RotateRightRightCase(current);
            }
        }
        return current;
    }
    private static Node RotateLeftLeftCase(Node current)
    {
        Node pivot = current.Left;
        current.Left = pivot.Right;
        pivot.Right = current;
        UpdateHeight(current);
        pivot = UpdateHeight(pivot);
        return pivot;
    }

    private static Node RotateLeftRightCase(Node current)
    {
        current.Left = RotateRightRightCase(current.Left);
        return RotateLeftLeftCase(current);
    }

    private static Node RotateRightLeftCase(Node current)
    {
        current.Right = RotateLeftLeftCase(current.Right);
        return RotateRightRightCase(current);
    }

    private static Node RotateRightRightCase(Node current)
    {
        Node pivot = current.Right;
        current.Right = pivot.Left;
        pivot.Left = current;
        UpdateHeight(current);
        pivot = UpdateHeight(pivot);
        return pivot;
    }

    private static int GetBalanceFactor(Node current)
    {
        int leftHeight = current.Left?.Height ?? 0;
        int rightHeight = current.Right?.Height ?? 0;
        return leftHeight - rightHeight;
    }

    private static Node UpdateHeight(Node current)
    {
        int leftHeight = current.Left?.Height ?? 0;
        int rightHeight = current.Right?.Height ?? 0;
        current.Height = Math.Max(leftHeight, rightHeight) + 1;
        return current;
    }
}

