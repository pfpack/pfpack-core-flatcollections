using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // Initializes an instance in 'as is' mode without any processing
        //
        // Since the invariant of Builder implies the empty Builder contains null underlying array,
        // the caller MUST ensure the length is GREATER than zero

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Builder(int length)
        {
            Debug.Assert(length != default);

            this.length = length;
            items = new T[length];
            isBuilt = false;
        }
    }
}
