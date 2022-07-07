using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class FlatArrayExtensions
{
    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this T[]? source)
        =>
        source is not null ? FlatArray<T>.InternalFactory.FromArray(source) : null;

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this FlatArray<T>? source)
        =>
        source is not null ? FlatArray<T>.InternalFactory.FromFlatArray(source) : null;

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this List<T>? source)
        =>
        source is not null ? FlatArray<T>.InternalFactory.FromList(source) : null;

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        FlatArray<T>.InternalFactory.FromImmutableArray(source);

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        source is not null ? FlatArray<T>.InternalFactory.FromImmutableArray(source.Value) : null;

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this IEnumerable<T>? source)
        =>
        source is not null ? FlatArray<T>.InternalFactory.FromIEnumerable(source) : null;
}
