using System.Collections;

namespace Piligrimm.Structures;

public class Queue<T> : IEnumerable<T>, ICollection, IEnumerable
{
    private T[] _array;
    private int _capacity = 5; // 5 is default capacity
    private int _count = 0;
    private int _current = 0; // value which declare a pointer on value in array

    public int Count => _count - _current;

    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();

    public Queue()
    {
        _array = new T[_capacity];
    }

    public Queue(IEnumerable<T> values) : this()
    {
        foreach (var value in values)
        {
            Enqueue(value);
        }
    }

    /// <summary> Добавляет элемент в конец Queue<T> </summary>
    /// <param name="item"> Item </param>
    public void Enqueue(T item)
    {
        _array[_count] = item;
        _count++;

        if (_count == _capacity)
        {
            _capacity *= 2;
            var newArray = new T[_capacity];

            CopyTo(newArray, 0);
            _array = newArray;
        }
    }

    /// <summary> Удаляет самый старый элемент из начала Queue<T>. </summary>
    /// <returns> T </returns>
    public T? Dequeue()
    {
        if (_count == 0 || _current >= _count)
            throw new InvalidOperationException("Queue is empty");

        _current++;

        return _array[_current - 1];
    }

    /// <summary> Функция просмотра возвращает самый старый элемент, который находится в начале Queue<T> , но не удаляет его из Queue<T>.  </summary>
    /// <returns> T </returns>
    public T? Peek()
    {
        if (_count == 0 || _current >= _count)
            throw new InvalidOperationException("Queue is empty");

        return _array[_current];
    }

    public void Clear()
    {
        _array = new T[_capacity];
        _count = 0;
        _current = 0;
    }

    public void CopyTo(Array array, int index)
    {
        var queue = GetEnumerator();

        for (int i = 0; queue.MoveNext(); i++)
        {
            array.SetValue(queue.Current, index + i);
        }
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = _current; i < _count; i++)
        {
            yield return _array[i];
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = _current; i < _count; i++)
        {
            yield return _array[i];
        }
    }
}