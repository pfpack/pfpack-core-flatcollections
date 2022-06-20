using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
        : InnerFactory.Build(source);

    public FlatArray([AllowNull] List<T> source)
        =>
        items = source is null
        ? InnerEmptyArray.Value
        : InnerFactory.Build(source);

    public FlatArray([AllowNull] IReadOnlyCollection<T> source)
        =>
        items = source switch
        {
            null => InnerEmptyArray.Value,

            T[] array => InnerFactory.Build(array),

            List<T> list => InnerFactory.Build(list),

            ICollection<T> coll => InnerFactory.Build(coll),

            var coll => InnerFactory.Build(coll)
        };

    public FlatArray([AllowNull] IEnumerable<T> source)
        =>
        items = source switch
        {
            null => InnerEmptyArray.Value,

            T[] array => InnerFactory.Build(array),

            List<T> list => InnerFactory.Build(list),

            ICollection<T> coll => InnerFactory.Build(coll),

            IReadOnlyCollection<T> coll => InnerFactory.Build(coll),

            var coll => InnerFactory.Build(coll)
        };
}
