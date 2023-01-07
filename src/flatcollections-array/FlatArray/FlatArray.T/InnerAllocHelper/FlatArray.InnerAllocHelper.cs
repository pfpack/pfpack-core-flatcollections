using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
        // Default capacity for cases where capacity must be greater than zero
        internal const int DefaultNonZeroCapacity = 4;

        internal static int EnsureNonZeroCapacity(int capacity)
            =>
            capacity > 0 ? capacity : DefaultNonZeroCapacity;

        // The caller MUST ensure the length is GREATER than zero
        // and the max capacity is NOT LESS than the length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EstimateCapacity(int length, int maxCapacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(maxCapacity >= length);

            int capacity = unchecked(length * 2);

            if (capacity < 0) // handle the overflow case
            {
                return maxCapacity;
            }

            if (capacity > maxCapacity)
            {
                return maxCapacity;
            }

            return capacity;
        }

        // The caller MUST ensure the length is GREATER than zero
        // and the capacity is NOT LESS than the length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(capacity >= length);

            int doubleLength = unchecked(length * 2);

            if (doubleLength < 0) // handle the overflow case
            {
                return false;
            }

            return doubleLength <= capacity;
        }
    }
}
