using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    // Initializes an instance without any processing and creation of a defensive copy
    //
    // Since the invariant of FlatArray implies the empty FlatArray contains null underlying array,
    // the caller MUST ensure the length is GREATER than zero
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private FlatArray(T[] items, int _)
    {
        Debug.Assert(items is not null);
        Debug.Assert(items.Length != default);

        length = items.Length;
        this.items = items;
    }

    // Initializes an instance without any processing and creation of a defensive copy
    //
    // Since the invariant of FlatArray implies the empty FlatArray contains null underlying array,
    // the caller MUST ensure the length is GREATER than zero
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private FlatArray(int length, T[] items)
    {
        Debug.Assert(items is not null);
        Debug.Assert(length > 0 && length <= items.Length);

        this.length = length;
        this.items = items;
    }

    // Initializes an instance in the completely raw mode
    //
    // The caller MUST ensure the parameter values accord with the FlatArray invariant
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private FlatArray(int length, T[]? items, int _)
    {
        Debug.Assert(
            length == default && items is null ||
            items is not null && length > 0 && length <= items.Length);

        this.length = length;
        this.items = items;
    }
}
