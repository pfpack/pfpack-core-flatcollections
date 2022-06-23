using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> Empty
        =>
        InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        source?.Length > 0 ? new(InnerCloneArray(source), default) : InnerEmptyFlatArray.Value;

    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        InnerFrom(source);

    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        InnerFrom(source);

    private static FlatArray<T> InnerFrom(IEnumerable<T>? source)
    {
        throw new NotImplementedException();
    }
}
