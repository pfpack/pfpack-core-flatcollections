using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source is null ? default : InnerFactory.FromArray(source);

    public static FlatArray<T> From(FlatArray<T> source)
        =>
        InnerFactory.FromFlatArray(source);

    public static FlatArray<T> From(FlatArray<T>? source)
        =>
        source is null ? default : InnerFactory.FromFlatArray(source.Value);

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is null ? default : InnerFactory.FromList(source);

    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InnerFactory.FromImmutableArray(source);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        source is null ? default : InnerFactory.FromImmutableArray(source.Value);

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        source switch
        {
            null => default,

            T[] array
            =>
            InnerFactory.FromArray(array),

            List<T> list
            =>
            InnerFactory.FromList(list),

            FlatArray<T> flatArray
            =>
            InnerFactory.FromFlatArray(flatArray),

            ImmutableArray<T> immutableArray
            =>
            InnerFactory.FromImmutableArray(immutableArray),

            ICollection<T> coll
            =>
            InnerFactory.FromICollection(coll),

            IReadOnlyList<T> list
            =>
            InnerFactory.FromIReadOnlyList(list),

            IReadOnlyCollection<T> coll
            =>
            InnerFactory.FromIEnumerable(coll, coll.Count),

            _ =>
            InnerFactory.FromIEnumerable(source)
        };
}
