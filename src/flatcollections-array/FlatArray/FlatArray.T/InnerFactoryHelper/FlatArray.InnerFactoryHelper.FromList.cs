using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromList(List<T> source)
        {
            var count = source.Count;

            if (count == default)
            {
                return default;
            }

            var array = new T[count];
#if NET8_0_OR_GREATER
            source.CopyTo(new Span<T>(array));
#else
            source.CopyTo(array);
#endif

            return new(array, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromList([AllowNull] List<T> source, int start, int length)
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
}
