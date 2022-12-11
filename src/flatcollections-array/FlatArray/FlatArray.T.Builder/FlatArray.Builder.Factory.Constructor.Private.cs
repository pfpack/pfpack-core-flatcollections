using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // Initializes an instance in 'as is' mode without any processing and creation of a defensive copy
        //
        // Since the invariant of the Builder implies the empty Builder with zero capacity contains null underlying array,
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
