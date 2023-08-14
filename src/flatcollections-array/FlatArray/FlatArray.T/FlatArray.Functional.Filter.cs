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

        InternalForEach(
            item =>
            {
                if (predicate.Invoke(item) is false)
                {
                    return;
                }

                if (resultLength == resultItems.Length)
                {
                    InnerBufferHelper.EnlargeBuffer(ref resultItems);
                }

                resultItems[resultLength++] = item;
            });

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

        InternalForEach(
            (i, item) =>
            {
                if (predicate.Invoke(item, i) is false)
                {
                    return;
                }

                if (resultLength == resultItems.Length)
                {
                    InnerBufferHelper.EnlargeBuffer(ref resultItems);
                }

                resultItems[resultLength++] = item;
            });

        if (resultLength == default)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }
}