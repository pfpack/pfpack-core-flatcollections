using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    // Delegate null (empty) check to the caller; delegate range check to the array indexer
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref readonly T InternalItem(int index)
        =>
        ref items![index];
}
