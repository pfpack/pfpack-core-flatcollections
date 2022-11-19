using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // Initializes an instance in 'as is' mode without any processing and creation of a defensive copy
        //
        // Since the invariant of Builder implies the empty Builder contains null underlying array,
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
            isBuilt = false;
        }
    }
}
