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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(FlatArray<T> source)
    {
        if (source.length == default)
        {
            this = default;
            return;
        }

        length = source.length;
        items = InnerArrayHelper.Copy(source.items!, source.length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(FlatArray<T>? source)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(ImmutableArray<T> source)
    {
        if (source.IsDefaultOrEmpty)
        {
            this = default;
            return;
        }

        var items = new T[source.Length];
#if NET7_0_OR_GREATER
        source.CopyTo(new Span<T>(items));
#else
        source.CopyTo(items);
#endif

        length = source.Length;
        this.items = items;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(ImmutableArray<T>? source)
    {
        var sourceValue = source.GetValueOrDefault();

        if (sourceValue.IsDefaultOrEmpty)
        {
            this = default;
            return;
        }

        var items = new T[sourceValue.Length];
#if NET7_0_OR_GREATER
        sourceValue.CopyTo(new Span<T>(items));
#else
        sourceValue.CopyTo(items);
#endif

        length = sourceValue.Length;
        this.items = items;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(ReadOnlySpan<T> source)
    {
        if (source.IsEmpty)
        {
            this = default;
            return;
        }

        length = source.Length;
        items = source.ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FlatArray(Span<T> source)
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
