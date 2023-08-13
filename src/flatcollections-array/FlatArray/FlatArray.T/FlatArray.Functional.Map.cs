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

        InternalForEach(
            (i, item) => resultItems[i] = map.Invoke(item));

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

        InternalForEach(
            (i, item) => resultItems[i] = map.Invoke(item, i));

        return new(resultItems, default);
    }
}