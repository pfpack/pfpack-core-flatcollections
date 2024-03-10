using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] T[] source, int start, int length)
        =>
        InnerFactoryHelper.FromArray(source, start, length);
}
