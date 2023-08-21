using System.Runtime.CompilerServices;

namespace System;

partial class FlatArray
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T>.Builder Empty<T>()
            =>
            new();

        // TODO: Add the tests and make public
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T>.Builder Empty<T>(int capacity)
            =>
            FlatArray<T>.Builder.InternalEmptyChecked(capacity);
    }
}
