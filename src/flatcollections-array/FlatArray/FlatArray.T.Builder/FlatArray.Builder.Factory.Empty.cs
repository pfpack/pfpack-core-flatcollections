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
            InternalEmptyChecked(capacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Builder InternalEmptyChecked(
            int capacity, [CallerArgumentExpression(nameof(capacity))] string paramName = "")
        {
            if (capacity < 0)
            {
                throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(paramName, capacity);
            }

            return new(capacity: capacity);
        }
    }
}
