using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

public static class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
