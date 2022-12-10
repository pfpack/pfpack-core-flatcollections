using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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

    /*
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InnerIsValidState() // For only use in Debug.Assert
        =>
        length == default && items is null ||
        length == default && items is not null && items.Length > 0 ||
        length > 0 && items is not null && length <= items.Length;
    */

    [MemberNotNullWhen(returnValue: true, nameof(items))]
    private bool InnerIsNotEmpty
        =>
        length != default;

    [MemberNotNullWhen(returnValue: false, nameof(items))]
    private bool InnerIsEmpty
        =>
        length == default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T[] InnerItems()
        =>
        InnerIsNotEmpty ? items : InnerEmptyArray.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ReadOnlySpan<T> InnerAsSpan()
        =>
        InnerIsNotEmpty ? new(items, 0, length) : ReadOnlySpan<T>.Empty;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ReadOnlyMemory<T> InnerAsMemory()
        =>
        InnerIsNotEmpty ? new(items, 0, length) : ReadOnlyMemory<T>.Empty;
}
