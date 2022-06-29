using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray
{
    public static FlatArray<T> Empty<T>()
        =>
        FlatArray<T>.Empty;

    public static FlatArray<T> From<T>([AllowNull] params T[] source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>([AllowNull] FlatArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>([AllowNull] List<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>([AllowNull] IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
