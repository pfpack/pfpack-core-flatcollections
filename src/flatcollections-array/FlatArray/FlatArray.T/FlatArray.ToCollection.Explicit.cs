using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

        return InnerToList(length, items);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<T> InnerToList(int length, T[] items)
        {
            // Passing FlatList (or ArraySegment) to the constructor leads to the same efficient behavior
            // like in the case of 'new(items)' above, i.e., to calling ICollection<T>.CopyTo
            // and then to calling efficient Array.Copy
            //
            // Thus, it should be the most efficient way to build a list in this case
            //
            var effectiveItems = new FlatList(length, items);
            return new(effectiveItems);
        }
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
            return ImmutableArray.Create(items);
        }

#if NET7_0_OR_GREATER
        return ImmutableArray.Create(new ReadOnlySpan<T>(items, 0, length));
#else
        return ImmutableArray.Create(items, 0, length);
#endif
    }
}
