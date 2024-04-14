namespace Piligrimm;

public class LinkedListNode<T>
{
    public LinkedListNode<T>? Next;
    public LinkedListNode<T>? Previous;

    public T Data;

    public LinkedListNode(T data)
    {
        Data = data;
    }
}