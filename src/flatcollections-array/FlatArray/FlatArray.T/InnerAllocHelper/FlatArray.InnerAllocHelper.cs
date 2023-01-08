using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
        // Default capacity for cases where capacity must be greater than zero
        internal const int DefaultPositiveCapacity = 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnsurePositiveCapacity(int capacity)
            =>
            capacity > 0 ? capacity : DefaultPositiveCapacity;

        // The caller MUST ensure the length is GREATER than zero,
        // and the length is LESS than or EQUAL to the max capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EstimateCapacity(int length, int maxCapacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(length <= maxCapacity);

            int doubleLength = unchecked(length * 2);

            return unchecked((uint)doubleLength) <= unchecked((uint)maxCapacity)
                ? doubleLength
                : maxCapacity;
        }

        // The caller MUST ensure the length is GREATER than zero,
        // and the length is LESS than or EQUAL to the capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(length <= capacity);

            // Double length within the capacity means a huge capacity

            int doubleLength = unchecked(length * 2);

            return unchecked((uint)doubleLength) <= unchecked((uint)capacity);
        }
    }
}
