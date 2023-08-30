using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is null ? default : InnerFactoryHelper.FromICollectionTrusted(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] List<T> source, int start, int length)
    {
        InnerValidateRange();

        if (source is null || length == default)
        {
            return default;
        }

        var array = new T[length];
        source.CopyTo(start, array, 0, length);

        return new(array, default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void InnerValidateRange()
        {
            var sourceLength = source?.Count ?? default;
            if (InnerAllocHelper.IsSegmentWithinBounds(start, length, sourceLength))
            {
                return;
            }
            throw InnerExceptionFactory.SegmentOutsideBounds(start, length, sourceLength);
        }
    }
}
