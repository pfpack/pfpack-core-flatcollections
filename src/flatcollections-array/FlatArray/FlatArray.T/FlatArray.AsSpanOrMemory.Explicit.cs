using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan()
        =>
        InnerAsSpan();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory()
        =>
        InnerAsMemory();
}
