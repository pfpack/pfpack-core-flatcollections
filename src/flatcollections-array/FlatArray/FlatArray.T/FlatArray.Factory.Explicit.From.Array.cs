using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] params T[] source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] T[] source, int start, int length)
    {
        InnerValidateRange();

        return source is null || length == default
            ? default
            : new(InnerArrayHelper.CopySegment(source, start, length), default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void InnerValidateRange()
        {
            var sourceLength = source?.Length ?? default;
            if (InnerAllocHelper.IsSegmentWithinLength(start, length, sourceLength))
            {
                return;
            }
            throw InnerExceptionFactory.SegmentIsNotWithinArray(start, length, sourceLength);
        }
    }
}
