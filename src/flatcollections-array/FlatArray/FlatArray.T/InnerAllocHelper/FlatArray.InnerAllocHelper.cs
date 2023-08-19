using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
        internal const int DefaultPositiveCapacity = 4;

        // The caller MUST ensure the length is GREATER than or EQUAL to zero
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsIndexInRange(int index, int length)
        {
            Debug.Assert(length >= 0);

            return unchecked((uint)index) < unchecked((uint)length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsWithinLength(int value, int length)
            =>
            InnerIsWithin(value, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnsurePositiveCapacity(int capacity)
            =>
            capacity > 0 ? capacity : DefaultPositiveCapacity;

        // The caller MUST ensure the capacity is GREATER than or EQUAL to zero
        internal static int EnsureCapacityWithinDefaultPositive(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return InnerIsWithin(capacity, DefaultPositiveCapacity) ? capacity : DefaultPositiveCapacity;
        }

        // The caller MUST ensure the capacity is GREATER than zero and LESS than the max capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnlargeCapacity(int capacity, int maxCapacity)
        {
            Debug.Assert(capacity > 0 && capacity < maxCapacity);

            int newCapacity = InnerDoubleUnchecked(capacity);
            return InnerIsWithin(newCapacity, maxCapacity) ? newCapacity : maxCapacity;
        }

        // The caller MUST ensure the length is GREATER than zero and LESS than or EQUAL to the capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0 && length <= capacity);

            if (InnerIsWithin(capacity, DefaultPositiveCapacity))
            {
                return false;
            }

            int doubleLength = InnerDoubleUnchecked(length);
            return InnerIsWithin(doubleLength, capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerDoubleUnchecked(int value)
            =>
            value << 1; // unchecked(value * 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InnerIsWithin(int value, int threshold)
            =>
            unchecked((uint)value) <= unchecked((uint)threshold);
    }
}
