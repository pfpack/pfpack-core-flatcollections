namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> Map<TResult>(Func<T, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (IsEmpty)
        {
            return default;
        }

        var resultItems = new TResult[length];

        for (int i = 0; i < length; i++)
        {
            resultItems[i] = map.Invoke(items![i]);
        }

        return new(resultItems, default);
    }

    public FlatArray<TResult> Map<TResult>(Func<T, int, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (IsEmpty)
        {
            return default;
        }

        var resultItems = new TResult[length];

        for (int i = 0; i < length; i++)
        {
            resultItems[i] = map.Invoke(items![i], i);
        }

        return new(resultItems, default);
    }
}