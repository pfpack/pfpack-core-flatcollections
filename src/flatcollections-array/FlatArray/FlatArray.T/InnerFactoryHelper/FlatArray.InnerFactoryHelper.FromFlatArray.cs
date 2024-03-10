using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromFlatArray(FlatArray<T> source, int start, int length)
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
    }
}
