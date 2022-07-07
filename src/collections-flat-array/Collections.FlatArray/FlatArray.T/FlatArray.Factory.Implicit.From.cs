using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(T[]? source)
        =>
        source is null ? null : InternalFactory.FromArray(source);

    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(List<T>? source)
        =>
        source is null ? null : InternalFactory.FromList(source);

    public static implicit operator FlatArray<T>(ImmutableArray<T> source)
        =>
        InternalFactory.FromImmutableArray(source);

    [return: NotNullIfNotNull("source")]
    public static implicit operator FlatArray<T>?(ImmutableArray<T>? source)
        =>
        source is null ? null : InternalFactory.FromImmutableArray(source.Value);
}
