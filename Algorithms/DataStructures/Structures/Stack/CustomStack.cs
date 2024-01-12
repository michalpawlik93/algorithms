namespace DataStructures.Structures.Queue;

/// <summary>
/// Stack based on array approach
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomStack<T> : QueueBase<T>
{
    public CustomStack(int size) : base(size) { }

    public override void Enqueue(T item)
    {
        ResizeQueueCheck();
        Collection[TailIndex++] = item;
    }

    public override T Dequeue() => TailIndex <= 0 ? default : Collection[HeadIndex++];
}
