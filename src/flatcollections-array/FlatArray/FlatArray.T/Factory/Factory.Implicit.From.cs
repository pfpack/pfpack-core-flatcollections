using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FlatArray<T>([AllowNull] T[] source)
        =>
        new(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FlatArray<T>([AllowNull] List<T> source)
        =>
        From(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FlatArray<T>(ImmutableArray<T> source)
        =>
        new(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FlatArray<T>(ReadOnlySpan<T> source)
        =>
        new(source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FlatArray<T>(Span<T> source)
        =>
        new(source);
}
