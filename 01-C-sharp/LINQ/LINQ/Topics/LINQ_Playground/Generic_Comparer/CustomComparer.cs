public class CustomComparer<T, TKey> : IEqualityComparer<T>
{
    private readonly Func<T, TKey> _keySelector;

    public CustomComparer(Func<T, TKey> keySelector)
    {
        _keySelector = keySelector;
    }

    public bool Equals(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x == null || y == null) return false;

        return EqualityComparer<TKey>.Default.Equals(_keySelector(x), _keySelector(y));
    }

    public int GetHashCode(T obj)
    {
        if (obj == null) return 0;
        return _keySelector(obj)?.GetHashCode() ?? 0;
    }
}