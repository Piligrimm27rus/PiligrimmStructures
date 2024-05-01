using System.Collections;

namespace Piligrimm.Structures;

public class Stack<T> : IEnumerable<T>, ICollection
{
    private int _count = 0;
    private Node? currentNode;

    public int Count => _count;
    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();

    public Stack() { }

    public Stack(params T[] values)
    {
        foreach (var item in values)
        {
            Push(item);
        }
    }

    public void CopyTo(Array array, int index)
    {
        if (array.Length < _count)
            throw new ArgumentException("CopyTo method. Destination array was not long enough.");
        
        if (array.Length < index || array.Length - index < _count)
            throw new ArgumentException("CopyTo method. Destination index was long enough then array length.");


        var stackEnumerator = GetEnumerator();
        
        for (int i = 0; stackEnumerator.MoveNext(); i++)
        {
            array.SetValue(stackEnumerator.Current, index + i);
        }
    }

    public void Push(T item)
    {
        currentNode = new Node(item, currentNode);
        _count++;
    }

    public T Pop()
    {
        if (_count == 0 || currentNode is null)
            throw new InvalidOperationException("Stack is empty");

        T data = currentNode.Data;
        currentNode = currentNode?.Previous;
        _count--;


        return data;
    }

    public T Peek()
    {
        if (_count == 0 || currentNode is null)
            throw new InvalidOperationException("Stack is empty");

        return currentNode.Data;
    }

    public void Clear()
    {
        _count = 0;
        currentNode = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? _currentNode = null;
        for (int i = 0; i < _count; i++)
        {
            _currentNode = _currentNode is null ? currentNode : _currentNode.Previous;

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            yield return _currentNode.Data;
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class Node
    {
        public T Data { get; set; }
        public Node? Previous { get; set; }

        public Node(T item, Node? node = null)
        {
            Data = item;
            Previous = node;
        }
    }
}

