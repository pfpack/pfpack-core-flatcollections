using System.Collections.Immutable;

namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>(ImmutableArray<T> source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(ImmutableArray<T> source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);

    public static FlatArray<T> From<T>(ImmutableArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>(ImmutableArray<T>? source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);
}
