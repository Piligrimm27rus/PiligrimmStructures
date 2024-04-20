namespace Piligrimm.Structures;

public class LinkedListNode<T>
{
    public LinkedListNode<T>? Next;
    public LinkedListNode<T>? Previous;

    public T Value;

    public LinkedListNode(T value)
    {
        Value = value;
    }
}