using System.Runtime.CompilerServices;

namespace System;

partial class FlatArray
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FlatArray<T> Empty<T>()
        =>
        default;
}
