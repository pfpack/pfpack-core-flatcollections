using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray(T[] source)
            =>
            InnerFrom_Array(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromFlatArray(FlatArray<T> source)
            =>
            InnerFrom_FlatArray(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromList(List<T> source)
            =>
            InnerFrom_List(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromImmutableArray(ImmutableArray<T> source)
            =>
            InnerFrom_ImmutableArray(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromIEnumerable(IEnumerable<T> source)
            =>
            source switch
            {
                T[] array
                =>
                InnerFrom_Array(array),

                List<T> list
                =>
                InnerFrom_List(list),

                FlatArray<T> flatArray
                =>
                InnerFrom_FlatArray(flatArray),

                ImmutableArray<T> immutableArray
                =>
                InnerFrom_ImmutableArray(immutableArray),

                ICollection<T> coll
                =>
                InnerFrom_ICollection(coll),

                IReadOnlyList<T> list
                =>
                InnerFrom_IReadOnlyList(list),

                IReadOnlyCollection<T> coll
                =>
                InnerFrom_IEnumerable(coll, coll.Count),

                _ =>
                InnerFrom_IEnumerable(source)
            };
    }
}
