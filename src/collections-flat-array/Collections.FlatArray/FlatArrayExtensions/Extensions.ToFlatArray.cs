using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class FlatArrayExtensions
{
    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this FlatArray<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        FlatArray<T>.From(source);

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IReadOnlyList<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);
}
