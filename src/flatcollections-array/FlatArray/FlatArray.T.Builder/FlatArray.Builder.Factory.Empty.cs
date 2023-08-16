using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder Empty()
            =>
            new();

        // TODO: Add the tests and make public
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder Empty(int capacity)
            =>
            InternalEmptyChecked(capacity, nameof(capacity));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalEmptyChecked(int capacity, string paramName)
        {
            if (capacity is not >= 0)
            {
                throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(paramName, capacity);
            }

            return new(capacity: capacity);
        }
    }
}
