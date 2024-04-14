using System.Collections;

namespace Piligrimm;

public class LinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
{
    private int _count = 0;


    public int Count => _count;

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();
    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
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

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private class Node
    {
        public T Data { get; set; }
        public Node? Next { get; set; }

        public Node(T item, Node? node = null)
        {
            Data = item;
            Next = node;
        }
    }
}