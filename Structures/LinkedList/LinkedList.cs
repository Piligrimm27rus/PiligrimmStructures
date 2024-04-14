using System.Collections;

namespace Piligrimm;

public class LinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
{
    private int _count = 0;
    private LinkedListNode<T>? _lastNode;
    private LinkedListNode<T>? _firstNode;

    public int Count => _count;

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();
    public bool IsReadOnly => throw new NotImplementedException();

    public LinkedList(params T[] values)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    public void Add(T item)
    {
        if (_firstNode is null && _lastNode is null)
        {
            _firstNode = _lastNode = new LinkedListNode<T>(item);

            _firstNode.Next = _lastNode;
            _lastNode.Next = _firstNode;

            _firstNode.Previous = _lastNode;
            _lastNode.Previous = _firstNode;
        }
        else
        {
            var newNode = new LinkedListNode<T>(item);

            _lastNode.Next = newNode;

            newNode.Next = _firstNode;
            newNode.Previous = _lastNode;

            _lastNode = newNode;
        }

        _count++;
    }

    public void Clear()
    {
        _firstNode = null;
        _lastNode = null;

        _count = 0;
    }

    public bool Contains(T item)
    {
        // for (int i = 0;)
        return false;
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerator GetEnumerator()
    {
        LinkedListNode<T>? current = null;
        for (int i = 0; i < _count; i++)
        {
            current = current is null ? _firstNode : current.Next;

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            yield return current.Data;
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        LinkedListNode<T>? current = null;
        for (int i = 0; i < _count; i++)
        {
            current = current is null ? _firstNode : current.Next;

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            yield return current.Data;
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}