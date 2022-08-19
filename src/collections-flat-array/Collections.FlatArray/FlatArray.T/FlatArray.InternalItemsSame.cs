using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool InternalItemsSame(FlatArray<T> left, FlatArray<T> right)
        =>
        ReferenceEquals(left.items, right.items);
}
