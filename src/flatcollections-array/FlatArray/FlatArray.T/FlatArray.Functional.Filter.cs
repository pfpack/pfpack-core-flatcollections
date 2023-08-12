namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Filter(Predicate<T> predicate)
    {
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        if (length == default)
        {
            return default;
        }

        var resultItems = new T[length];
        var resultLength = 0;

        for (int i = 0; i < length; i++)
        {
            var item = items![i];

            if (predicate.Invoke(item) is false)
            {
                continue;
            }

            resultItems[resultLength] = item;
            resultLength++;
        }

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

        var resultItems = new T[length];
        var resultLength = 0;

        for (int i = 0; i < length; i++)
        {
            var item = items![i];

            if (predicate.Invoke(item, i) is false)
            {
                continue;
            }

            resultItems[resultLength] = item;
            resultLength++;
        }

        if (resultLength == default)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }
}