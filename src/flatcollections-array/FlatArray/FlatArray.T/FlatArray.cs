using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace System;

#if NET8_0_OR_GREATER
[CollectionBuilder(typeof(FlatArray), nameof(FlatArray.From))]
#endif
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
}
