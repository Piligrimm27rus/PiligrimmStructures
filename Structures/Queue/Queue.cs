using System.Collections;

namespace Piligrimm.Structures;

public class Queue<T> : IEnumerable<T>, ICollection, IEnumerable
{
    private T[] _array;
    private int _capacity = 5;
    private int _count = 0;

    private int _left = 0;
    private int _right = 0;

    public int Count => _count;

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
        _array[_right] = item;

        _count++;
        _right = ++_right % _capacity;

        if (_right == _left)
        {
            _capacity *= 2;
            var newArr = new T[_capacity];

            Array.Copy(_array, _left, newArr, 0, (_capacity / 2) - _left);
            Array.Copy(_array, 0, newArr, (_capacity / 2) - _left, _right);

            _array = newArr;

            _left = 0;
            _right = _count;
        }
    }

    /// <summary> Удаляет самый старый элемент из начала Queue<T>. </summary>
    /// <returns> T </returns>
    public T? Dequeue()
    {
        if (_count == 0 || _left == _right)
            throw new InvalidOperationException("Queue is empty");

        var item = _array[_left];
        _array[_left] = default;

        _left = ++_left % _capacity;
        _count--;

        return item;
    }

    /// <summary> Функция просмотра возвращает самый старый элемент, который находится в начале Queue<T> , но не удаляет его из Queue<T>.  </summary>
    /// <returns> T </returns>
    public T? Peek()
    {
        if (_count == 0 || _left == _right)
            throw new InvalidOperationException("Queue is empty");

        return _array[_left];
    }

    public void Clear()
    {
        _array = new T[_capacity];
        _count = 0;

        _right = 0;
        _left = 0;
    }

    public void CopyTo(Array array, int index) => _array.CopyTo(array, index);

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _array[(_left + i) % _capacity];
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _array[(_left + i) % _capacity];
        }
    }
}