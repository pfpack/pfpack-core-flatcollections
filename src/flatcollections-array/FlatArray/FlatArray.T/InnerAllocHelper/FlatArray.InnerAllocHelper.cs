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

            return InnerIsWithinUnchecked(value, length);
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
        internal static bool IsWithinCapacityUnchecked(int value, int capacity)
            =>
            InnerIsWithinUnchecked(value, capacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnsurePositiveCapacity(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return capacity > 0 ? capacity : DefaultPositiveCapacity;
        }

        internal static int EnsureCapacityWithinDefaultPositive(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return InnerIsWithinUnchecked(capacity, DefaultPositiveCapacity) ? capacity : DefaultPositiveCapacity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnlargeCapacity(int capacity, int maxCapacity)
        {
            Debug.Assert(capacity > 0 && capacity < maxCapacity);

            int newCapacity = DoubleUnchecked(capacity);
            return InnerIsWithinUnchecked(newCapacity, maxCapacity) ? newCapacity : maxCapacity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0 && length <= capacity);

            if (InnerIsWithinUnchecked(capacity, DefaultPositiveCapacity))
            {
                return false;
            }

            int doubleLength = DoubleUnchecked(length);
            return InnerIsWithinUnchecked(doubleLength, capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int DoubleUnchecked(int value)
            =>
            value << 1; // unchecked(value * 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InnerIsWithinUnchecked(int value, int threshold)
            =>
            unchecked((uint)value) <= unchecked((uint)threshold);
    }
}
