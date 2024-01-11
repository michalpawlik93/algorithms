using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Structures.Hashing;

/// <summary>
/// Custom dictionary where key is a string
/// </summary>
/// <typeparam name="TValue"></typeparam>
public sealed class CustomDictionary<TValue>
{
    private const int DefaultCapacity = 100;
    private const double LoadFactor = 0.75;
    private KeyValue<int, LinkedList<KeyValue<string, TValue>>>[] HashTable { get; set; }
    private int CurrentLength;

    public CustomDictionary()
    {
        HashTable = new KeyValue<int, LinkedList<KeyValue<string, TValue>>>[DefaultCapacity];
    }

    public void AddValue(string key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(key);
        if (CurrentLength >= LoadFactor * HashTable.Length)
        {
            ResizeAndRehash();
        }
        int hash = HashFunction(key);
        var newValue = new KeyValue<string, TValue>(key, value);
        AddToLinkedList(hash, newValue, HashTable);
        CurrentLength++;
    }

    public TValue GetValue(string key) =>
        (
            HashTable[HashFunction(key)]?.Value.FirstOrDefault(x => x.Key == key)
            ?? throw new KeyNotFoundException()
        ).Value;

    private int HashFunction(string key, int hashTableLength = DefaultCapacity) =>
        Math.Abs(key.GetHashCode() % hashTableLength);

    private void ResizeAndRehash()
    {
        int newCapacity = HashTable.Length * 2;
        var newHashTable = new KeyValue<int, LinkedList<KeyValue<string, TValue>>>[newCapacity];

        foreach (var item in HashTable.Where(i => i.Key != 0))
        {
            foreach (var linkedListItem in item.Value)
            {
                int newHash = HashFunction(linkedListItem.Key, newCapacity);
                AddToLinkedList(newHash, linkedListItem, newHashTable);
            }
        }

        HashTable = newHashTable;
    }

    private void AddToLinkedList(
        int hash,
        KeyValue<string, TValue> item,
        KeyValue<int, LinkedList<KeyValue<string, TValue>>>[] hashTable
    )
    {
        if (hashTable[hash] == null)
        {
            LinkedList<KeyValue<string, TValue>> linkedList = new();
            linkedList.AddFirst(item);
            HashTable[hash] = new(hash, linkedList);
        }
        else
        {
            HashTable[hash].Value.AddLast(item);
        }
    }
}

public record KeyValue<TKey, TValue>(TKey Key, TValue Value);
