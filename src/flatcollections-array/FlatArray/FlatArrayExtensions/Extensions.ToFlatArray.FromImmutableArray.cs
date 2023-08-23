using System.Collections.Immutable;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> ToFlatArray<T>(this ImmutableArray<T>? source)
        =>
        FlatArray<T>.From(source);
}
