using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this FlatArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this FlatArray<T>? source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
