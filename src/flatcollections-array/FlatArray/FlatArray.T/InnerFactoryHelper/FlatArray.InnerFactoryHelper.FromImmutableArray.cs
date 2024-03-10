using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class InnerFactoryHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FlatArray<T> FromImmutableArray(ImmutableArray<T> source, int start, int length)
        {
            InnerValidateRange();

            if (length == default)
            {
                return default;
            }

            var array = new T[length];
            source.CopyTo(start, array, 0, length);

            return new(array, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void InnerValidateRange()
            {
                var sourceLength = source.IsDefault ? default : source.Length;
                if (InnerAllocHelper.IsSegmentWithinBounds(start, length, sourceLength))
                {
                    return;
                }
                throw InnerExceptionFactory.SegmentOutsideBounds(start, length, sourceLength);
            }
        }
    }
}
