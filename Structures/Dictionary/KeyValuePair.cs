namespace Piligrimm.Structures;

class KeyValuePair<TKey, TValue>
{
    public TKey Key { get; internal set; }
    public TValue Value { get; internal set; }

    public KeyValuePair(TKey Key, TValue Value)
    {
        this.Key = Key;
        this.Value = Value;
    }
}