using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    internal static FlatArray<T> InternalFromIEnumerable(IEnumerable<T> source)
        =>
        source switch
        {
            T[] array
            =>
            InternalFromArray(array),

            List<T> list
            =>
            InternalFromList(list),

            FlatArray<T> flatArray
            =>
            InternalFromFlatArray(flatArray),

            ImmutableArray<T> immutableArray
            =>
            InternalFromImmutableArray(immutableArray),

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
