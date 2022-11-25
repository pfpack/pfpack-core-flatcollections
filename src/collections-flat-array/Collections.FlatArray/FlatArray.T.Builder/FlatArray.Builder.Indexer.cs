using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public ref T this[int index]
        {
            // Delegate range check to the indexer for performance purposes
            // IndexOutOfRangeException will be thrown
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref span[index];
        }
    }
}
