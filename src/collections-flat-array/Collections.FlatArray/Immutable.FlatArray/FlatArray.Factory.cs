using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Immutable;

partial class FlatArray
{
    public static FlatArray<T> Empty<T>()
        =>
        FlatArray<T>.Empty;

    public static FlatArray<T> From<T>([AllowNull] params T[] source)
        =>
        new(source);

    public static FlatArray<T> From<T>([AllowNull] List<T> source)
        =>
        new(source);

    public static FlatArray<T> From<T>([AllowNull] IEnumerable<T> source)
        =>
        new(source);
}
