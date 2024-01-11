﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace System;

[JsonConverter(typeof(FlatArrayJsonConverterFactory))]
[DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
public readonly partial struct FlatArray<T> : IEquatable<FlatArray<T>>
{
    private readonly int length;

    private readonly T[]? items;

    public int Length
        =>
        length;

    public bool IsNotEmpty
        =>
        length != default;

    public bool IsEmpty
        =>
        length == default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T[] InnerItems()
        =>
        length == default ? InnerEmptyArray.Value : items!;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ReadOnlySpan<T> InnerAsSpan()
    {
        if (length == default)
        {
#pragma warning disable IDE0301 // Simplify collection initialization
            return ReadOnlySpan<T>.Empty;
#pragma warning restore IDE0301 // Simplify collection initialization
        }

        if (length == items!.Length)
        {
            return new(items);
        }

        return new(items, 0, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ReadOnlyMemory<T> InnerAsMemory()
    {
        if (length == default)
        {
            return ReadOnlyMemory<T>.Empty;
        }

        if (length == items!.Length)
        {
            return new(items);
        }

        return new(items, 0, length);
    }
}
