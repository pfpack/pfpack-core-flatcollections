using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(ImmutableArray<T> source)
        =>
        InnerFactory.FromImmutableArray(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T> source, int start, int length)
        =>
        InternalFromImmutableArrayChecked(source, start, length);

    public static FlatArray<T> From(ImmutableArray<T>? source)
        =>
        InnerFactory.FromImmutableArray(source.GetValueOrDefault());

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(ImmutableArray<T>? source, int start, int length)
        =>
        InternalFromImmutableArrayChecked(source.GetValueOrDefault(), start, length);

    internal static FlatArray<T> InternalFromImmutableArrayChecked(ImmutableArray<T> source, int start, int length)
    {
        var sourceLength = source.IsDefault ? default : source.Length;

        if (InnerAllocHelper.IsSegmentWithin(start, length, sourceLength) is not true)
        {
            throw InnerExceptionFactory.SegmentIsNotWithinArray(start, length, sourceLength);
        }

        return InnerFactory.FromImmutableArray(source, start, length);
    }
}
