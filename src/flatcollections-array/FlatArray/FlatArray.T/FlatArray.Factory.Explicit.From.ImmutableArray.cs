using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InnerFactory.FromImmutableArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T> source, int length)
        =>
        InternalFromImmutableArrayChecked(source, length);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        InnerFactory.FromImmutableArray(source.GetValueOrDefault());

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T>? source, int length)
        =>
        InternalFromImmutableArrayChecked(source.GetValueOrDefault(), length);

    internal static FlatArray<T> InternalFromImmutableArrayChecked(ImmutableArray<T> source, int length)
    {
        var actualLength = source.IsDefault ? default : source.Length;

        if (InnerAllocHelper.IsWithin(length, actualLength) is not true)
        {
            throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(nameof(length), length, actualLength);
        }

        return InnerFactory.FromImmutableArray(source, length);
    }
}
