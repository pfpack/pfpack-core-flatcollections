using System.Collections.Immutable;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T>? source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);
}
