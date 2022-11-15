using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

//[JsonConverter(typeof(FlatArrayJsonConverterFactory))]
[DebuggerDisplay($"{nameof(Length)} = {{{nameof(Length)}}}")]
public readonly partial struct FlatArray<T> :
    IReadOnlyList<T>,
    IEquatable<FlatArray<T>>,
    ICloneable
{
    private readonly int length;

    private readonly T[]? items;

    public int Length
        =>
        length;

    int IReadOnlyCollection<T>.Count
        =>
        length;

    public bool IsNotEmpty
        =>
        length != default;

    public bool IsEmpty
        =>
        length == default;

    [MemberNotNullWhen(returnValue: true, nameof(items))]
    private bool InnerIsNotEmpty
        =>
        length != default;

    [MemberNotNullWhen(returnValue: false, nameof(items))]
    private bool InnerIsEmpty
        =>
        length == default;
}
