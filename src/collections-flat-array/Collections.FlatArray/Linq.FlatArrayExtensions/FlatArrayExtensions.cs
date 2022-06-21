using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

public static class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        new(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        new(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        new(source);
}
