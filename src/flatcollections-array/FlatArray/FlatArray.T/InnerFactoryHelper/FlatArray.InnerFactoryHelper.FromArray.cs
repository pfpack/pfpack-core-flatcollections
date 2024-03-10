using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromArray([AllowNull] T[] source, int start, int length)
        {
            InnerValidateRange();

            return source is null || length == default
                ? default
                : new(InnerArrayHelper.CopySegment(source, start, length), default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void InnerValidateRange()
            {
                var sourceLength = source?.Length ?? default;
                if (InnerAllocHelper.IsSegmentWithinBounds(start, length, sourceLength))
                {
                    return;
                }
                throw InnerExceptionFactory.SegmentOutsideBounds(start, length, sourceLength);
            }
        }
    }
}
