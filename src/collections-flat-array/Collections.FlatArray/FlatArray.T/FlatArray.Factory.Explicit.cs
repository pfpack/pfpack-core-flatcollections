using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> Empty
        =>
        InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        new(source);

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        new(source);

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        new(source);
}
