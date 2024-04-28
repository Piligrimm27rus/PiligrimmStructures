namespace Piligrimm.Structures;

public class LinkedListNode<T>
{
    public LinkedListNode<T>? Next { get; internal set; }
    public LinkedListNode<T>? Previous { get; internal set; }

    public T Value;

    public LinkedListNode(T value)
    {
        Value = value;
    }
}