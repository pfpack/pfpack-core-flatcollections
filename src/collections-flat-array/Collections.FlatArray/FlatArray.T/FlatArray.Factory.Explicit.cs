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

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is not null ? InnerFromICollection(source) : InnerEmptyFlatArray.Value;

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

            ImmutableArray<T> immutableArray
            =>
            InnerFromImmutableArray(immutableArray),

            ICollection<T> collection
            =>
            InnerFromICollection(collection),

            _ =>
            InnerFromIEnumerable(source)
        };

    private static FlatArray<T> InnerFromArray(T[] source)
        =>
        source.Length > 0 ? new(InnerCloneArray(source), default) : InnerEmptyFlatArray.Value;

    private static FlatArray<T> InnerFromImmutableArray(ImmutableArray<T> source)
        =>
        source.IsDefault is false ? InnerFromICollection(source) : InnerEmptyFlatArray.Value;

    private static FlatArray<T> InnerFromICollection(ICollection<T> source)
    {
        var count = source.Count;
        if (count is not > 0)
        {
            return InnerEmptyFlatArray.Value;
        }

        var array = new T[count];
        source.CopyTo(array, 0);

        // Clone for the safety purposes
        return new(InnerCloneArray(array), default);
    }

    private static FlatArray<T> InnerFromIEnumerable(IEnumerable<T> source)
    {
        using var enumerator = source.GetEnumerator();

        if (enumerator.MoveNext() is false)
        {
            return InnerEmptyFlatArray.Value;
        }

        int count = 0;
        var array = new T[4];

        do
        {
            if (count < array.Length)
            {
                array[count++] = enumerator.Current;
            }
            else
            {
                Array.Resize(ref array, array.Length * 2);
                array[count++] = enumerator.Current;
            }
        }
        while (enumerator.MoveNext());

        if (count < array.Length)
        {
            Array.Resize(ref array, count);
        }

        return new(array, default);
    }
}
