using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T[](FlatArray<T> flatArray)
        =>
        flatArray.ToArray();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator List<T>(FlatArray<T> flatArray)
        =>
        flatArray.ToList();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ImmutableArray<T>(FlatArray<T> flatArray)
        =>
        flatArray.ToImmutableArray();
}
