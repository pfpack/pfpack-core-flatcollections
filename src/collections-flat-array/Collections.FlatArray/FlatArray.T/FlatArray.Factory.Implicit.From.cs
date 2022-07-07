using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(T[]? source)
        =>
        source is not null ? InternalFactory.FromArray(source) : null;

    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(List<T>? source)
        =>
        source is not null ? InternalFactory.FromList(source) : null;

    public static implicit operator FlatArray<T>(ImmutableArray<T> source)
        =>
        InternalFactory.FromImmutableArray(source);

    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(ImmutableArray<T>? source)
        =>
        source is not null ? InternalFactory.FromImmutableArray(source.Value) : null;
}
