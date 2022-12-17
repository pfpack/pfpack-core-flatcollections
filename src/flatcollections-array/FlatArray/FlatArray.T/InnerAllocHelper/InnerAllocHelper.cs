using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
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
    }
}
