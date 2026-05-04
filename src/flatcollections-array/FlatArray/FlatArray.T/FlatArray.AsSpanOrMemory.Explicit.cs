using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan()
    {
        if (length == default)
        {
            return ReadOnlySpan<T>.Empty;
        }

        return length == items!.Length
            ? new(items)
            : new(items, 0, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory()
    {
        if (length == default)
        {
            return ReadOnlyMemory<T>.Empty;
        }

        return length == items!.Length
            ? new(items)
            : new(items, 0, length);
    }
}
