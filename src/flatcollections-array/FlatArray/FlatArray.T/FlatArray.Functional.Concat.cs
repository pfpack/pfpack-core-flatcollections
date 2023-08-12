using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Concat(FlatArray<T> other)
    {
        if (other.length == default)
        {
            return this;
        }

        if (length == default)
        {
            return other;
        }

        var resultItems = InnerArrayHelper.Concat(items!, length, other.items!, other.length);
        return new(resultItems, default);
    }

    public FlatArray<T> Concat([AllowNull] params T[] other)
    {
        if (other is null || other.Length == default)
        {
            return this;
        }

        if (length == default)
        {
            var otherClone = InnerArrayHelper.Clone(other);
            return new(otherClone, default);
        }

        var resultItems = InnerArrayHelper.Concat(items!, length, other, other.Length);
        return new(resultItems, default);
    }
}