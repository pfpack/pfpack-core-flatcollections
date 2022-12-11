using System.Runtime.CompilerServices;

namespace System;

partial class FlatArray
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T>.Builder Empty<T>()
            =>
            new();

        // TODO: Make public when dynamic builder is implemented
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T>.Builder Empty<T>(int capacity)
            =>
            FlatArray<T>.Builder.InternalEmpty(capacity, nameof(capacity));
    }
}
