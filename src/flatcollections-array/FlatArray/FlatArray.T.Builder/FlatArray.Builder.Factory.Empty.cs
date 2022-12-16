using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder Empty()
            =>
            new();

        // TODO: Make public when dynamic builder is implemented
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder Empty(int capacity)
            =>
            InternalEmpty(capacity, nameof(capacity));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalEmpty(int capacity, string paramName)
        {
            if (capacity is not >= 0)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(paramName, capacity);
            }

            return new(capacity);
        }
    }
}
