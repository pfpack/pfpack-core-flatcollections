using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T InternalItemGet(int index)
        =>
        items[index]; // delegate range check to array indexer
}
