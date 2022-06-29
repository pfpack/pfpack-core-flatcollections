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
        source is not null ? InnerFromArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] FlatArray<T> source)
        =>
        source is not null ? InnerFromFlatArray(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is not null ? InnerFromList(source) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InnerFromImmutableArray(source);

    public static FlatArray<T> From([AllowNull] IReadOnlyList<T> source)
        =>
        source switch
        {
            null
            =>
            InnerEmptyFlatArray.Value,

            ImmutableArray<T> immutableArray
            =>
            InnerFromImmutableArray(immutableArray),

            _ =>
            InnerFromIReadOnlyList(source)
        };

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        source switch
        {
            null
            =>
            InnerEmptyFlatArray.Value,

            T[] array
            =>
            InnerFromArray(array),

            List<T> list
            =>
            InnerFromList(list),

            FlatArray<T> flatArray
            =>
            InnerFromFlatArray(flatArray),

            ImmutableArray<T> immutableArray
            =>
            InnerFromImmutableArray(immutableArray),

            ICollection<T> coll
            =>
            InnerFromICollection(coll),

            IReadOnlyList<T> list
            =>
            InnerFromIReadOnlyList(list),

            _ =>
            InnerFromIEnumerable(source)
        };
}
