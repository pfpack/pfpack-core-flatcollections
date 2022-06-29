using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class FlatArrayExtensions
{
    // From Array:

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        source is null ? null : FlatArray<T>.From(source);


    // From FlatArray:

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this FlatArray<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);


    // From List:

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);


    // From ImmutableArray:

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        FlatArray<T>.From(source);

    [return: NotNullIfNotNull("source")]
    public static FlatArray<T>? ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        source is null ? null : FlatArray<T>.From(source.Value);


    // From IReadOnlyList:

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IReadOnlyList<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);


    // From IEnumerable:

    [return: MaybeNull, NotNullIfNotNull("source")]
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        source is null ? null : FlatArray<T>.From(source);
}
