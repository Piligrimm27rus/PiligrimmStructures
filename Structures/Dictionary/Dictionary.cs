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
            System.Console.WriteLine($"key - {key} - {key.GetHashCode()}");
            int index = Math.Abs(key.GetHashCode()) % _array.Length;
            var pair = _array[index]?.FirstOrDefault(pairs => key.Equals(pairs.Key));

            if (pair is null)
                throw new ArgumentException("Key isn't exists");

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
                throw new ArgumentException("Key isn't exists");

            pair.Value = value;
        }
    }

    public void Add(K key, V value)
    {
        if (key is null)
            throw new ArgumentNullException("Key is null");
            System.Console.WriteLine($"key - {key} - {key.GetHashCode()}");

        int index = Math.Abs(key.GetHashCode()) % _array.Length;

        if (_array[index] is not null)
        {
            foreach (var keyValuePair in _array[index])
            {
                if (key.Equals(keyValuePair.Key))
                    throw new ArgumentException($"{key} key already exists");
            }
        }

        if (_count + 1 > _array.Length)
            Recreate();

        if (_array[index] is null)
            _array[index] = new List<KeyValuePair<K, V>>();

        _array[index].Add(new KeyValuePair<K, V>(key, value));

        _count++;
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

internal class HashHelper
{
    public static ReadOnlySpan<int> Primes =>
    [
        3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
        1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
        17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
        187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
        1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
    ];

    public static int NextPrime(int prime)
    {
        for (int i = 0; i < Primes.Length; i++)
        {
            if (Primes[i] > prime)
                return Primes[i];
        }
        return -1;
    }
}