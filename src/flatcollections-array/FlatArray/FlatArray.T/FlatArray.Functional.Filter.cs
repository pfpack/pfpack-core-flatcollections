namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Filter(Func<T, bool> predicate)
    {
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        if (length == default)
        {
            return default;
        }

        var initialCapacity = InnerAllocHelper.EnsureCapacityWithinDefaultPositive(length);

        var resultItems = new T[initialCapacity];
        var resultLength = 0;

        var counter = 0;
        do
        {
            if (predicate.Invoke(items![counter]) is not true)
            {
                continue;
            }

            if (resultLength == resultItems.Length)
            {
                InnerBufferHelper.EnlargeBuffer(ref resultItems);
            }

            resultItems[resultLength++] = items![counter];
        }
        while (++counter < resultItems.Length);

        if (resultLength == default)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }

    public FlatArray<T> Filter(Func<T, int, bool> predicate)
    {
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        if (length == default)
        {
            return default;
        }

        var initialCapacity = InnerAllocHelper.EnsureCapacityWithinDefaultPositive(length);

        var resultItems = new T[initialCapacity];
        var resultLength = 0;

        var counter = 0;
        do
        {
            if (predicate.Invoke(items![counter], counter) is not true)
            {
                continue;
            }

            if (resultLength == resultItems.Length)
            {
                InnerBufferHelper.EnlargeBuffer(ref resultItems);
            }

            resultItems[resultLength++] = items![counter];
        }
        while (++counter < resultItems.Length);

        if (resultLength == default)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }
}