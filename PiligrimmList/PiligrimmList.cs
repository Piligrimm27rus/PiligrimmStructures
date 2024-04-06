using System.Collections;

namespace Piligrimm;

public class PiligrimmList<T> : IEnumerable<T>, ICollection<T>
{
    private T[] _array;
    private int _capacity = 5; // 5 is default value when list will be created (cuz as I want)
    private int _count = 0;

    public int Count => _count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public PiligrimmList()
    {
        _array = new T[_capacity];
    }

    public PiligrimmList(params T[] items) : base()
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        _array[_count] = item;
        _count++;

        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Copy(_array, new T[_capacity], _capacity);
        }
    }

    public void Clear()
    {
        _count = 0;
        Array.Clear(_array, 0, _capacity);
    }

    public bool Contains(T data)
    {
        foreach (var item in _array)
        {
            return (object)data == (object)item;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        array = new T[_count - arrayIndex];

        for (int i = 0; i < _count; i++)
        {
            array[i] = _array[arrayIndex + i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _array[i];
        }
    }

    public bool Remove(T data)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_array is not null && _array[i].Equals(data))
            {
                _array[i] = default(T);
                return true;
            }
        }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return _array[0];
    }
}