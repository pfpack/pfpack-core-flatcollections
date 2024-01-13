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

        return InnerToImmutableArray(length, items);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ImmutableArray<T> InnerToImmutableArray(int length, T[] items)
        {
            //return ImmutableArray.Create(items, 0, length);

            // Simple ImmutableArray.Create(items, start, length) assigns the array items in a cycle
            // While Builder.AddRange uses Array.Copy like the ImmutableArray.Create(items) above
            //
            // Likely, Create(items, start, length) has this behavior for performance purposes
            // since in general it is intended for copying small array segments
            //
            // But we need to copy the whole array within its effective length
            // Thus, using the Builder might be more efficient in this case
            //
            var builder = ImmutableArray.CreateBuilder<T>(initialCapacity: length);
            builder.AddRange(items, length);

            // Call MoveToImmutable instead of ToImmutable to avoid creating redundant defensive copy
            // We've ensured Builder.Count equals Builder.Capacity to avoid throwing the exception
            Debug.Assert(builder.Count == builder.Capacity);
            return builder.MoveToImmutable();
        }
    }
}
