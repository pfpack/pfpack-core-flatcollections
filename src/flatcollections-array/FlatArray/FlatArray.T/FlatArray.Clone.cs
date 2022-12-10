using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        InnerClone();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private FlatArray<T> InnerClone()
        =>
        InnerIsNotEmpty ? new(InnerArrayHelper.Copy(items, length), default) : default;
}
