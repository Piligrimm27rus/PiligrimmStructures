using System.Collections;

namespace Piligrimm.Structures;

public class LinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
{
    private int _count = 0;
    private LinkedListNode<T>? _lastNode;
    private LinkedListNode<T>? _firstNode;

    public int Count => _count;
    public LinkedListNode<T>? First => _firstNode;
    public LinkedListNode<T>? Last => _lastNode;

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
        }
        else if (_firstNode == _lastNode)
        {
            _lastNode = new LinkedListNode<T>(item);
            _lastNode.Previous = _firstNode;
            _firstNode.Next = _lastNode;
        }
        else
        {
            var newNode = new LinkedListNode<T>(item);

            _lastNode.Next = newNode;
            newNode.Previous = _lastNode;

            _lastNode = newNode;
        }

        _count++;
    }

    public void AddFirst(LinkedListNode<T> node) => AddFirst(node.Value);

    public void AddFirst(T item)
    {
        var newNode = new LinkedListNode<T>(item);

        newNode.Next = _firstNode;
        _firstNode.Previous = newNode;

        _firstNode = newNode;

        _count++;
    }

    public void AddAfter(LinkedListNode<T> node, T item) => AddAfter(node, new LinkedListNode<T>(item));

    public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
    {
        // если последняя нода
        if (node.Next == null)
        {
            node.Next = newNode;
            newNode.Previous = node;
            _lastNode = newNode;
        }
        // если в середине
        else
        {
            var next = node.Next;

            node.Next = newNode;
            newNode.Next = next;
            newNode.Previous = node;
            next.Previous = newNode;
        }

        _count++;
    }

    public void AddBefore(LinkedListNode<T> node, T item) => AddBefore(node, new LinkedListNode<T>(item));

    public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
    {

        if (node.Previous == null)
        {
            node.Previous = newNode;
            newNode.Next = node;
            _firstNode = newNode;
        }
        else
        {
            var previous = node.Previous;

            node.Previous = newNode;
            newNode.Previous = previous;
            newNode.Next = node;
            previous.Next = newNode;
        }
        _count--;
    }

    public void AddLast(LinkedListNode<T> node) => AddLast(node.Value);

    public void AddLast(T item)
    {
        Add(item);
    }

    public LinkedListNode<T> FindLast(T item)
    {
        if (item is null) return null;

        LinkedListNode<T>? current = null;

        for (int i = _count; i > 0; i--)
        {
            current = current == null ? _lastNode : current.Previous;
            if (item.Equals(current.Value))
            {
                return current;
            }
        }

        return null;
    }

    public LinkedListNode<T>? Find(T item)
    {
        if (item is null) return null;

        LinkedListNode<T>? current = null;

        for (int i = 0; i < _count; i++)
        {
            current = current == null ? _lastNode : current.Previous;
            if (item.Equals(current.Value)) return current;
        }
        return null;
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
        var linkedListEnumerator = GetEnumerator();

        for (int i = 0; linkedListEnumerator.MoveNext(); i++)
        {
            array.SetValue(linkedListEnumerator.Current, index + i);
        }
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var linkedListEnumerator = GetEnumerator();

        for (int i = 0; linkedListEnumerator.MoveNext(); i++)
        {
            array.SetValue(linkedListEnumerator.Current, arrayIndex + i);
        }
    }

    public void RemoveLast()
    {
        _lastNode = _lastNode.Previous;
        _count--;
    }

    public void RemoveFirst()
    {
        _firstNode = _firstNode.Next;
        _count--;
    }

    public bool Remove(LinkedListNode<T> node) => Remove(node.Value);

    public bool Remove(T item)
    {
        // FIXME PLS
        var node = Find(item);
        if (node is null) return false;

        if (node == First) RemoveFirst();
        else if (node == Last) RemoveLast();
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        return true;
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
            yield return current.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        // FIXME: do the same methods for GetEnumerator | for distinct both
        LinkedListNode<T>? current = null;
        for (int i = 0; i < _count; i++)
        {
            current = current is null ? _firstNode : current.Next;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            yield return current.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}