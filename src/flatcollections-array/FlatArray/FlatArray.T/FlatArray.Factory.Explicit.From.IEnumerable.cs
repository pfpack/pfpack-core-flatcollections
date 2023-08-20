using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
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
