using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> Empty
        =>
        InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source is not null ? InternalFromArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] FlatArray<T> source)
        =>
        source is not null ? InternalFromFlatArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is not null ? InternalFromList(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InternalFromImmutableArray(source);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        source is not null ? InternalFromImmutableArray(source.Value) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] IReadOnlyList<T> source)
        =>
        source is not null ? InternalFromIReadOnlyList(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        source is not null ? InternalFromIEnumerable(source) : InnerEmptyFlatArray.Value;
}
