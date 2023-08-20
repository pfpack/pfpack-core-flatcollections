using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>([AllowNull] params T[] source)
        =>
        FlatArray<T>.From(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From<T>([AllowNull] T[] source, int length)
        =>
        FlatArray<T>.InternalFromArrayChecked(source, length);
}
