using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
        internal const int DefaultPositiveCapacity = 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsIndexInRange(int index, int length)
        {
            Debug.Assert(length >= 0);

            return unchecked((uint)index) < unchecked((uint)length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsWithinLength(int value, int length)
        {
            Debug.Assert(value >= 0);
            Debug.Assert(length >= 0);

            return IsWithin(value, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSegmentWithinLength(int segmentStart, int segmentLength, int length)
        {
            Debug.Assert(segmentStart >= 0);
            Debug.Assert(segmentLength >= 0);
            Debug.Assert(length >= 0);

            return (ulong)unchecked((uint)segmentStart) + unchecked((uint)segmentLength) <= unchecked((uint)length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsWithinCapacity(int value, int capacity)
            =>
            IsWithin(value, capacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnsurePositiveCapacity(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return capacity > 0 ? capacity : DefaultPositiveCapacity;
        }

        // The caller MUST ensure the capacity is GREATER than or EQUAL to zero
        internal static int EnsureCapacityWithinDefaultPositive(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return IsWithin(capacity, DefaultPositiveCapacity) ? capacity : DefaultPositiveCapacity;
        }

        // The caller MUST ensure the capacity is GREATER than zero and LESS than the max capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnlargeCapacity(int capacity, int maxCapacity)
        {
            Debug.Assert(capacity > 0 && capacity < maxCapacity);

            int newCapacity = DoubleUnchecked(capacity);
            return IsWithin(newCapacity, maxCapacity) ? newCapacity : maxCapacity;
        }

        // The caller MUST ensure the length is GREATER than zero and LESS than or EQUAL to the capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0 && length <= capacity);

            if (IsWithin(capacity, DefaultPositiveCapacity))
            {
                return false;
            }

            int doubleLength = DoubleUnchecked(length);
            return IsWithin(doubleLength, capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int DoubleUnchecked(int value)
            =>
            value << 1; // unchecked(value * 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsWithin(int value, int threshold)
            =>
            unchecked((uint)value) <= unchecked((uint)threshold);
    }
}
