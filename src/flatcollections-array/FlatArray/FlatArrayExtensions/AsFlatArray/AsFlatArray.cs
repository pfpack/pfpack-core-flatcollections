using System.Runtime.CompilerServices;

namespace System;

partial class FlatArrayExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FlatArray<T> AsFlatArray<T>(this T value)
        =>
        new(value);
}
