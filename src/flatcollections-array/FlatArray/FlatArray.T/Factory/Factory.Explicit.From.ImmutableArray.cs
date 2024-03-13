using System.Collections.Immutable;

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
        InnerFactoryHelper.FromImmutableArrayValidated(source, start, length);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T>? source, int start, int length)
        =>
        InnerFactoryHelper.FromImmutableArrayValidated(source.GetValueOrDefault(), start, length);
}
