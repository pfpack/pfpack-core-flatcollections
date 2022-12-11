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
        internal static Builder Empty(int capacity)
        {
            if (capacity is not >= 0)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            return capacity == default
                ? new()
                : new(default, new T[capacity]);
        }
    }
}
