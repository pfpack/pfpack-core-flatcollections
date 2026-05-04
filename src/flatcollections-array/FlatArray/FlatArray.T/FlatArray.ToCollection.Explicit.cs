using System.Collections.Generic;
using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public T[] ToArray()
        =>
        length == default ? Array.Empty<T>() : InnerArrayHelper.Copy(items!, length);

    public List<T> ToList()
    {
        if (length == default)
        {
            return new();
        }

        ReadOnlySpan<T> sourceSpan = length == items!.Length
            ? new(items)
            : new(items, 0, length);

        List<T> result = new(capacity: length);
        result.AddRange(sourceSpan);
        return result;
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (length == default)
        {
            return ImmutableArray<T>.Empty;
        }

        ReadOnlySpan<T> sourceSpan = length == items!.Length
            ? new(items)
            : new(items, 0, length);

        return ImmutableArray.Create(sourceSpan);
    }
}
