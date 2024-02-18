using System.Collections.Generic;
using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public T[] ToArray()
#pragma warning disable IDE0301 // Simplify collection initialization
        =>
        length == default ? Array.Empty<T>() : InnerArrayHelper.Copy(items!, length);
#pragma warning restore IDE0301 // Simplify collection initialization

    public List<T> ToList()
    {
        if (length == default)
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            return new();
#pragma warning restore IDE0028 // Simplify collection initialization
        }

#if NET8_0_OR_GREATER
        ReadOnlySpan<T> sourceSpan = length == items!.Length
            ? new(items)
            : new(items, 0, length);

        List<T> result = new(capacity: length);
        result.AddRange(sourceSpan);
        return result;
#else
        ICollection<T> sourceItems = length == items!.Length
            ? items
            : new ArraySegment<T>(items, 0, length);

        return new(sourceItems);
#endif
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (length == default)
        {
#pragma warning disable IDE0301 // Simplify collection initialization
            return ImmutableArray<T>.Empty;
#pragma warning restore IDE0301 // Simplify collection initialization
        }

#if NET7_0_OR_GREATER
        ReadOnlySpan<T> sourceSpan = length == items!.Length
            ? new(items)
            : new(items, 0, length);

        return ImmutableArray.Create(sourceSpan);
#else
        return length == items!.Length
            ? ImmutableArray.Create(items)
            : ImmutableArray.Create(items, 0, length);
#endif
    }
}
