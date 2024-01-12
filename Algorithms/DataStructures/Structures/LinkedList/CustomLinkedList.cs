using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.LinkedList;

public class CustomLinkedList<T> : IEnumerable<T>
{
    private Node<T> Head { get; set; }

    /// <summary>
    /// Time complexity O(N)
    /// Memory complexity O(1)
    /// </summary>
    public CustomLinkedList<T> InsertFirst(T data, Guid? id = null)
    {
        Node<T> node = new(data, id);
        if (Head == null)
        {
            Head = node;
            Head.Next = null;
        }
        else
        {
            node.Next = Head;
            Head = node;
        }
        return this;
    }

    /// <summary>
    /// Time complexity O(N)
    /// Memory complexity O(1)
    /// </summary>
    public CustomLinkedList<T> InsertLast(T data, Guid? id = null)
    {
        Node<T> node = new(data, id);
        if (Head == null)
        {
            Head = node;
            Head.Next = null;
        }
        else
        {
            var lastNode = GetLastNode(Head);
            lastNode.Next = node;
        }
        return this;
    }

    /// <summary>
    /// Methode to insert after given node
    /// </summary>
    /// <param name="prevNode"></param>
    /// argument must be the node from the list
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public CustomLinkedList<T> InsertAfter(Node<T> prevNode, T data, Guid? id = null)
    {
        ArgumentNullException.ThrowIfNull(prevNode);
        if (Head == null)
        {
            throw new ArgumentException("Argument prevNode can not be found in list");
        }
        else
        {
            Node<T> newNode = new(data, id);
            var targetNode = GetTargetNode(Head, prevNode);
            newNode.Next = targetNode.Next;
            targetNode.Next = newNode;
        }
        return this;
    }

    private Node<T> GetTargetNode(Node<T> node, Node<T> targetNode)
    {
        if (node == targetNode)
        {
            return node;
        }

        if (node.Next != null)
        {
            return GetTargetNode(node.Next, targetNode);
        }
        else
        {
            throw new ArgumentException("Argument prevNode can not be found in list");
        }
    }

    private Node<T> GetLastNode(Node<T> node) => node.Next != null ? GetLastNode(node.Next) : node;

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = Head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Node<T> : IEquatable<Node<T>>
{
    public Node(T data, Guid? id, Node<T> next = null)
    {
        Data = data;
        Next = next;
        Id = id ?? Guid.NewGuid();
    }

    public T Data { get; set; }
    public Guid Id { get; }
    public Node<T> Next { get; set; }

    public bool Equals(Node<T> other) => other != null && this.Id == other.Id;

    public override bool Equals(Object obj)
    {
        if (obj == null)
        {
            return false;
        }
        Node<T> node = obj as Node<T>;
        return this.Equals(node);
    }

    public override int GetHashCode() => this.Id.GetHashCode();

    public static bool operator ==(Node<T> node1, Node<T> node2) =>
        (object)node1 == null || ((object)node2) == null
            ? System.Object.Equals(node1, node2)
            : node1.Equals(node2);

    public static bool operator !=(Node<T> node1, Node<T> node2) => !(node1 == node2);
};
