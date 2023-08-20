using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // Initializes an instance without the capacity range check
        // The caller MUST ensure the capacity is GREATER than or EQUAL to zero
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(int capacity)
        {
            Debug.Assert(capacity >= 0);

            length = default;
            items = capacity == default ? InnerEmptyArray.Value : new T[capacity];
        }

        // Initializes an instance without the length range check
        // The caller MUST ensure the length is GREATER than or EQUAL to zero
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(int length, int _)
        {
            Debug.Assert(length >= 0);

            this.length = length;
            items = length == default ? InnerEmptyArray.Value : new T[length];
        }

        // Initializes an instance without any processing and creation of a defensive copy
        //
        // Since the invariant of the Builder implies an empty instance with the default capacity
        // contains the singleton underlying array,
        // the caller MUST ensure the length is GREATER than zero
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
