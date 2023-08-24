using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray([AllowNull] params T[] source)
    {
        if (source is null || source.Length == default)
        {
            this = default;
            return;
        }

        length = source.Length;
        items = InnerArrayHelper.Copy(source);
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FlatArray(ReadOnlySpan<T> source)
    {
        if (source.IsEmpty)
        {
            this = default;
            return;
        }

        length = source.Length;
        items = source.ToArray();
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FlatArray(Span<T> source)
    {
        if (source.IsEmpty)
        {
            this = default;
            return;
        }

        length = source.Length;
        items = source.ToArray();
    }
}
