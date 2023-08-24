using System.Collections.Immutable;
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
    internal FlatArray(FlatArray<T> source)
    {
        if (source.length == default)
        {
            this = default;
            return;
        }

        length = source.length;
        items = InnerArrayHelper.Copy(source.items!, source.length);
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FlatArray(FlatArray<T>? source)
    {
        var sourceValue = source.GetValueOrDefault();

        if (sourceValue.length == default)
        {
            this = default;
            return;
        }

        length = sourceValue.length;
        items = InnerArrayHelper.Copy(sourceValue.items!, sourceValue.length);
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FlatArray(ImmutableArray<T> source)
    {
        if (source.IsDefaultOrEmpty)
        {
            this = default;
            return;
        }

        var items = new T[source.Length];
        source.CopyTo(items);

        length = source.Length;
        this.items = items;
    }

    // TODO: Add the tests and make public
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FlatArray(ImmutableArray<T>? source)
    {
        var sourceValue = source.GetValueOrDefault();

        if (sourceValue.IsDefaultOrEmpty)
        {
            this = default;
            return;
        }

        var items = new T[sourceValue.Length];
        sourceValue.CopyTo(items);

        length = sourceValue.Length;
        this.items = items;
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
