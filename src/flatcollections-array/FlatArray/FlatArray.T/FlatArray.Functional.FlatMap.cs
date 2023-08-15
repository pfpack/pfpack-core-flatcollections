namespace System;

partial struct FlatArray<T>
{
    public FlatArray<TResult> FlatMap<TResult>(Func<T, FlatArray<TResult>> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultBuilder = new FlatArray<TResult>.Builder();

        var counter = 0;
        do
        {
            var slice = map.Invoke(items![counter]);
            _ = resultBuilder.AddRange(slice);
        }
        while (++counter < length);

        return resultBuilder.MoveToFlatArray();
    }

    public FlatArray<TResult> FlatMap<TResult>(Func<T, int, FlatArray<TResult>> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (length == default)
        {
            return default;
        }

        var resultBuilder = new FlatArray<TResult>.Builder();

        var counter = 0;
        do
        {
            var slice = map.Invoke(items![counter], counter);
            _ = resultBuilder.AddRange(slice);
        }
        while (++counter < length);

        return resultBuilder.MoveToFlatArray();
    }
}