using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(int capacity)
        {
            Debug.Assert(capacity >= 0);

            length = default;
            items = capacity == default ? InnerEmptyArray.Value : new T[capacity];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(int length, int capacity)
        {
            Debug.Assert(length >= 0);
            Debug.Assert(capacity >= length);

            this.length = length;
            items = capacity == default ? InnerEmptyArray.Value : new T[capacity];
        }

        // Initializes an instance without any processing and creation of a defensive copy
        //
        // Since the invariant of the Builder implies an empty instance with the default capacity
        // contains the singleton underlying array,
        // the caller MUST ensure the length is GREATER than zero
        //
        // Note: The unused arg is intended to separate this from the public one
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(T[] items, int _)
        {
            Debug.Assert(items.Length != default);

            length = items.Length;
            this.items = items;
        }
    }
}
