using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(FlatArray<T> source)
        =>
        new(source);

    public static FlatArray<T> From(FlatArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T> source, int start, int length)
        =>
        InnerFactoryHelper.FromFlatArray(source, start, length);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T>? source, int start, int length)
        =>
        InnerFactoryHelper.FromFlatArray(source.GetValueOrDefault(), start, length);
}
