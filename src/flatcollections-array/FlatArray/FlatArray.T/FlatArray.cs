using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace System;

[CollectionBuilder(typeof(FlatArray), nameof(FlatArray.From))]
[JsonConverter(typeof(FlatArrayJsonConverterFactory))]
[DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
public readonly partial struct FlatArray<T> : IEquatable<FlatArray<T>>
{
    private readonly int length;

    private readonly T[]? items;

    private T[] InnerItems
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => length == default ? InnerEmptyArray.Value : items!;
    }

    public int Length
        =>
        length;

    public bool IsNotEmpty
        =>
        length != default;

    public bool IsEmpty
        =>
        length == default;
}
