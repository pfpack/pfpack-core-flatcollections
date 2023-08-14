namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> Map<TResult>(Func<T, TResult> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultItems = new TResult[length];

        var counter = 0;
        do
        {
            resultItems[counter] = map.Invoke(items![counter]);
        }
        while (++counter < length);

        return new(resultItems, default);
    }

    public FlatArray<TResult> Map<TResult>(Func<T, int, TResult> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultItems = new TResult[length];

        var counter = 0;
        do
        {
            resultItems[counter] = map.Invoke(items![counter], counter);
        }
        while (++counter < length);

        return new(resultItems, default);
    }
}