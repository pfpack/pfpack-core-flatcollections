using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> ToFlatArray<T>([AllowNull] this T[] source, int start, int length)
        =>
        FlatArray<T>.From(source, start, length);
}
