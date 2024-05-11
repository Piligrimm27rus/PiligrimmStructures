using System.Collections;

namespace Piligrimm.Structures;

public class Dictionary<K, V> : ICollection, IEnumerable
{
    private List<KeyValuePair<K, V>>[] _array;
    private int _count = 0;

    public int Count => _count;

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public Dictionary()
    {
        _array = new List<KeyValuePair<K, V>>[HashHelper.Primes[0]];
    }

    public V this[K key]
    {
        get
        {
            if (key is null)
                throw new ArgumentNullException("Key is null");

            int index = Math.Abs(key.GetHashCode()) % _array.Length;
            var pair = _array[index]?.FirstOrDefault(pairs => key.Equals(pairs.Key));

            if (pair is null)
                throw new KeyNotFoundException("Key isn't exists");

            return pair.Value;
        }
        set
        {
            if (key is null)
                throw new ArgumentNullException("Key is null");

            int index = Math.Abs(key.GetHashCode()) % _array.Length;

            if (_array[index] is null)
                _array[index] = new List<KeyValuePair<K, V>>();

            var pair = _array[index].FirstOrDefault(pairs => key.Equals(pairs.Key));

            if (pair is null)
                _array[index].Add(new KeyValuePair<K, V>(key, value));
            else
                pair.Value = value;
        }
    }

    public void Add(K key, V value)
    {
        if (key is null)
            throw new ArgumentNullException("Key is null");

        int index = Math.Abs(key.GetHashCode()) % _array.Length;

        if (_array[index] is not null)
        {
            foreach (var keyValuePair in _array[index])
            {
                if (key.Equals(keyValuePair.Key))
                    throw new ArgumentException($"{key} key already exists");
            }
        }

        if (_array[index] is null)
            _array[index] = new List<KeyValuePair<K, V>>();

        _array[index].Add(new KeyValuePair<K, V>(key, value));

        _count++;

        if (_count > _array.Length)
            Recreate();
    }

    private void Recreate()
    {
        int newCapacity = HashHelper.NextPrime(_array.Length);

        var oldArray = new List<KeyValuePair<K, V>>[_array.Length];
        CopyTo(oldArray, 0);

        _array = new List<KeyValuePair<K, V>>[newCapacity];
        _count = 0;

        foreach (var list in oldArray)
            if (list is not null)
                foreach (var pairs in list)
                    Add(pairs.Key, pairs.Value);
    }

    public bool TryGetValue(K key, out V value)
    {
        if (key is null)
            throw new ArgumentNullException("Key is null");

        value = default;

        int index = Math.Abs(key.GetHashCode()) % _array.Length;

        if (_array[index] is not null)
        {
            var pair = _array[index].FirstOrDefault(pair => key.Equals(pair.Key));
            if (pair is not null)
            {
                value = pair.Value;
                return true;
            }
        }

        return false;
    }

    public bool ContainsKey(K key)
    {
        if (key is null)
            throw new ArgumentNullException("Key is null");

        int index = Math.Abs(key.GetHashCode()) % _array.Length;
        if (_array[index] is not null)
        {
            return _array[index].Any(pair => key.Equals(pair.Key));
        }

        return false;
    }

    public void Remove(K key)
    {
        if (key is null)
            throw new ArgumentNullException("Key is null");

        int index = Math.Abs(key.GetHashCode()) % _array.Length;

        if (_array[index] is not null)
        {
            var pair = _array[index].FirstOrDefault(pairs => key.Equals(pairs.Key));
            if (pair is not null)
                _array[index].Remove(pair);
        }
    }

    public void CopyTo(Array array, int index)
    {
        for (int i = 0; i < _array.Length; i++)
            array.SetValue(_array[i], index + i);
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var list in _array)
            if (list is not null)
                foreach (var items in list)
                    yield return items;
    }
}