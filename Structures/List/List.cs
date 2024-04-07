using System.Collections;

namespace Piligrimm;

public class List<T> : IEnumerable<T>, ICollection<T>
{
    private T[] _array;
    private int _capacity = 5; // 5 is default capacity
    private int _count = 0;

    public int Count => _count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public List()
    {
        _array = new T[_capacity];
    }

    public List(params T[] items) : this()
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void Add(T data)
    {
        _array[_count] = data;
        _count++;

        if (_count == _capacity)
        {
            _capacity *= 2;
            var newArray = new T[_capacity];

            Array.Copy(_array, newArray, _count);
            _array = newArray;
        }
    }

    public void Clear()
    {
        _count = 0;
        Array.Clear(_array, 0, _capacity);
    }

    public bool Contains(T data)
    {
        if (data is null)
            throw new ArgumentNullException("Contains method. Parameter cannot be null.");

        foreach (var item in _array)
        {
            if (item is not null && data.Equals(item))
                return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length < _array.Length)
            throw new ArgumentException("CopyTo method. Destination array was not long enough.");
        
        if (array.Length < arrayIndex || _array.Length < arrayIndex)
            throw new ArgumentException("CopyTo method. Destination index was long enough then array length.");


        for (int i = 0; i < _array.Length; i++)
        {
            array[arrayIndex + i] = _array[i];
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
        if (data is null)
            return false;

        int foundItemIndex = -1;

        for (int i = 0; i < _count; i++)
        {
            if (data.Equals(_array[i]))
            {
                foundItemIndex = i;
                break;
            }
        }

        if (foundItemIndex == -1)
            return false;

        var newArray = new T[_capacity];
        _count--;

        Array.Copy(_array, 0, newArray, 0, foundItemIndex);
        Array.Copy(_array, foundItemIndex + 1, newArray,  foundItemIndex,  _count);
        _array = newArray;

        return true;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return _array[0];
    }
}