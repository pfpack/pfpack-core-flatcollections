using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is null ? default : InnerFactory.FromList(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] List<T> source, int start, int length)
        =>
        InternalFromListChecked(source, start, length);

    internal static FlatArray<T> InternalFromListChecked([AllowNull] List<T> source, int start, int length)
    {
        var sourceLength = source?.Count ?? default;

        if (InnerAllocHelper.IsSegmentWithin(start, length, sourceLength) is not true)
        {
            throw InnerExceptionFactory.SegmentIsNotWithinArray(start, length, sourceLength);
        }

        return source is null ? default : InnerFactory.FromList(source, length);
    }
}
