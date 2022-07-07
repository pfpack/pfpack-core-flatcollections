using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source is not null ? InternalFactory.FromArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] FlatArray<T> source)
        =>
        source is not null ? InternalFactory.FromFlatArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is not null ? InternalFactory.FromList(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InternalFactory.FromImmutableArray(source);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        source is not null ? InternalFactory.FromImmutableArray(source.Value) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        source is not null ? InternalFactory.FromIEnumerable(source) : InnerEmptyFlatArray.Value;
}
