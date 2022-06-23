using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

public static class FlatArrayExtensions
{
    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);
}
