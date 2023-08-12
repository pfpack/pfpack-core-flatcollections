namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Concat(FlatArray<T> other)
    {
        if (IsEmpty)
        {
            return other;
        }

        if (other.IsEmpty)
        {
            return this;
        }

        var resultItems = new T[length + other.length];

        for (int i = 0; i < length; i++)
        {
            resultItems[i] = items![i];
        }

        for (var j = 0; j < other.length; j++)
        {
            resultItems[length + j] = other.items![j];
        }

        return new(resultItems, default);
    }

    public FlatArray<T> Concat(params T[] other)
    {
        if (IsEmpty)
        {
            return other;
        }

        if (other is null || other.Length is 0)
        {
            return this;
        }

        var resultItems = new T[length + other.Length];

        for (int i = 0; i < length; i++)
        {
            resultItems[i] = items![i];
        }

        for (var j = 0; j < other.Length; j++)
        {
            resultItems[length + j] = other[j];
        }

        return new(resultItems, default);
    }
}