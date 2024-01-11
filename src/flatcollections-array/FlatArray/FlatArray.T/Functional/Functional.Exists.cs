namespace System;

partial struct FlatArray<T>
{
    public bool Exists(Func<T, bool> predicate)
    {
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        if (length == default)
        {
            return default;
        }

        var counter = 0;
        do
        {
            if (predicate.Invoke(items![counter]))
            {
                return true;
            }
        }
        while (++counter < length);

        return false;
    }

    public bool Exists(Func<T, int, bool> predicate)
    {
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        if (length == default)
        {
            return default;
        }

        var counter = 0;
        do
        {
            if (predicate.Invoke(items![counter], counter))
            {
                return true;
            }
        }
        while (++counter < length);

        return false;
    }
}