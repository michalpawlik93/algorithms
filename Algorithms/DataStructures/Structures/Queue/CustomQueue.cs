namespace DataStructures.Structures.Queue;

/// <summary>
/// Queue based on array approach
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomQueue<T> : QueueBase<T>
{
    public CustomQueue(int size) : base(size) { }

    /// <summary>
    /// Time complexity O(1)
    /// Memory complexity O(1)
    /// Worst case when resizing O(n)
    /// </summary>
    /// <param name="item"></param>
    public override void Enqueue(T item)
    {
        ResizeQueueCheck();
        Collection[TailIndex++] = item;
    }

    /// <summary>
    /// Time complexity O(1)
    /// Memory complexity O(1)
    /// </summary>
    /// <returns></returns>
    public override T Dequeue()
    {
        if (HeadIndex > TailIndex)
        {
            return default;
        }
        T item = Collection[HeadIndex++];

        return item;
    }
}

public abstract class QueueBase<T>
{
    protected T[] Collection;
    protected int TailIndex = 0;
    protected int HeadIndex = 0;
    protected int Size;

    protected QueueBase(int size)
    {
        Collection = new T[size];
        Size = size;
    }

    public abstract void Enqueue(T item);
    public abstract T Dequeue();

    /// <summary>
    /// Not needed methode. Arrays are dynamic in c#.
    /// </summary>
    protected void ResizeQueueCheck()
    {
        if (TailIndex + 1 > Size)
        {
            ResizeQueue();
        }
    }

    private void ResizeQueue()
    {
        Size = Size * 2;
        var newQueue = new T[Size];
        Collection.CopyTo(newQueue, 0);
        Collection = newQueue;
    }
}
