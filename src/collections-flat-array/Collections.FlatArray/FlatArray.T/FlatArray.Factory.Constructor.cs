using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public FlatArray()
        =>
        items = InnerEmptyArray.Value;

    public FlatArray([AllowNull] params T[] source)
        =>
        items = source is null
        ? InnerEmptyArray.Value
        : InnerBuildItems(source);

    // TODO: Remove all the below constructors and move their logic to FlatArray<T>.From factories

    private FlatArray([AllowNull] List<T> source)
        =>
        items = source is null
        ? InnerEmptyArray.Value
        : InnerBuildItems(source.ToArray());

    private FlatArray([AllowNull] IEnumerable<T> source)
        =>
        items = source switch
        {
            null => InnerEmptyArray.Value,

            T[] array => InnerBuildItems(array),

            List<T> list => InnerBuildItems(list.ToArray()),

            var coll => InnerBuildItems(coll.ToArray())
        };

    private static T[] InnerBuildItems(T[] source)
        =>
        source.Length is not > 0
        ? InnerEmptyArray.Value
        : InnerCloneArray(source);
}
