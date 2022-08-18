using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T InternalGetItem(int index)
        =>
        items[index]; // delegate range check to array indexer
}
