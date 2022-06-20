using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    internal static class InnerFactory
    {
        internal static T[] Build(T[] source)
            =>
            InnerBuild(source);

        internal static T[] Build(List<T> source)
            =>
            source.Count is not > 0
            ? InnerEmptyArray.Value
            : InnerBuild(source.ToArray());

        internal static T[] Build(ICollection<T> source)
            =>
            source.Count is not > 0
            ? InnerEmptyArray.Value
            : InnerBuild(source.ToArray());

        internal static T[] Build(IReadOnlyCollection<T> source)
            =>
            source.Count is not > 0
            ? InnerEmptyArray.Value
            : InnerBuild(source.ToArray());

        internal static T[] Build(IEnumerable<T> source)
            =>
            source.TryGetNonEnumeratedCount(out var count) && count is not > 0
            ? InnerEmptyArray.Value
            : InnerBuild(source.ToArray());

        private static T[] InnerBuild(T[] source)
            =>
            source.Length is not > 0
            ? InnerEmptyArray.Value
            : InnerArrayHelper.Copy(source);
    }
}
