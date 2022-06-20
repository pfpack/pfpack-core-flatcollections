using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    public FlatArray()
        =>
        items = InnerEmptyArray.Value;

    public FlatArray([AllowNull] params T[] source)
        =>
        items = source is null
        ? InnerEmptyArray.Value
        : InnerBuild(source);

    public FlatArray([AllowNull] List<T> source)
        =>
        items = source is null
        ? InnerEmptyArray.Value
        : InnerBuild(source.ToArray());

    public FlatArray([AllowNull] IEnumerable<T> source)
        =>
        items = source switch
        {
            null => InnerEmptyArray.Value,

            T[] array => InnerBuild(array),

            List<T> list => InnerBuild(list.ToArray()),

            var coll => InnerBuild(coll.ToArray())
        };

    private static T[] InnerBuild(T[] source)
        =>
        source.Length is not > 0
        ? InnerEmptyArray.Value
        : InnerArrayHelper.Copy(source);
}
