using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From(FlatArray<T> source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T> source, int start, int length)
    {
        InnerValidateRange();

        return length == default
            ? default
            : new(InnerArrayHelper.CopySegment(source.items!, start, length), default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void InnerValidateRange()
        {
            if (InnerAllocHelper.IsSegmentWithinBounds(start, length, source.length))
            {
                return;
            }
            throw InnerExceptionFactory.SegmentOutsideBounds(start, length, source.length);
        }
    }

    public static FlatArray<T> From(FlatArray<T>? source)
        =>
        new(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From(FlatArray<T>? source, int start, int length)
        =>
        From(source.GetValueOrDefault(), start, length);
}
