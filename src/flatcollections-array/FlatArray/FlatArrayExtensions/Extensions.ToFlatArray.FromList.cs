using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source)
        =>
        FlatArray<T>.From(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> ToFlatArray<T>([AllowNull] this List<T> source, int start, int length)
        =>
        FlatArray<T>.InternalFromListChecked(source, start, length);
}
