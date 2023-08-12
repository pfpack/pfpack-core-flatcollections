namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Filter(Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (IsEmpty)
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

        if (resultLength is 0)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }

    public FlatArray<T> Filter(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (IsEmpty)
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

        if (resultLength is 0)
        {
            return default;
        }

        return new(resultLength, resultItems);
    }
}