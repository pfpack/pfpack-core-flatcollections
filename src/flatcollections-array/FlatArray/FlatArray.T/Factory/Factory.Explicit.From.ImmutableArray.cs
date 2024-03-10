using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        new(source);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T> source, int start, int length)
        =>
        InnerFactoryHelper.FromImmutableArray(source, start, length);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T>? source, int start, int length)
        =>
        InnerFactoryHelper.FromImmutableArray(source.GetValueOrDefault(), start, length);
}
