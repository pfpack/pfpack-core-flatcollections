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

        if (length == items!.Length)
        {
            return new(items);
        }

        // Pass FlatList to use effective collection copying
        // (ArraySegment also applicable)
        return new(new FlatList(length, items));
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (length == default)
        {
#pragma warning disable IDE0301 // Simplify collection initialization
            return ImmutableArray<T>.Empty;
#pragma warning restore IDE0301 // Simplify collection initialization
        }

        if (length == items!.Length)
        {
#if NET7_0_OR_GREATER
            return ImmutableArray.Create(new ReadOnlySpan<T>(items));
#else
            return ImmutableArray.Create(items);
#endif
        }

#if NET7_0_OR_GREATER
        return ImmutableArray.Create(new ReadOnlySpan<T>(items, 0, length));
#else
        return ImmutableArray.Create(items, 0, length);
#endif
    }
}
