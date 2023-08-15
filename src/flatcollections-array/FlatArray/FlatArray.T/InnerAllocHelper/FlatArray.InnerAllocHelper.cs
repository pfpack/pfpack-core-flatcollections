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
        internal static bool IsWithinCapacity(int value, int capacity)
            =>
            unchecked((uint)value) <= unchecked((uint)capacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnsurePositiveCapacity(int capacity)
            =>
            capacity > 0 ? capacity : DefaultPositiveCapacity;

        // The caller MUST ensure the capacity is GREATER than or EQUAL to zero
        internal static int EnsureCapacityWithinDefaultPositive(int capacity)
        {
            Debug.Assert(capacity >= 0);

            return IsWithinCapacity(capacity, DefaultPositiveCapacity) ? capacity : DefaultPositiveCapacity;
        }

        // The caller MUST ensure the capacity is GREATER than zero and LESS than the max capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int EnlargeCapacity(int capacity, int maxCapacity)
        {
            Debug.Assert(capacity > 0 && capacity < maxCapacity);

            int newCapacity = InnerDoubleUnchecked(capacity);
            return IsWithinCapacity(newCapacity, maxCapacity) ? newCapacity : maxCapacity;
        }

        // The caller MUST ensure the length is GREATER than zero and LESS than or EQUAL to the capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0 && length <= capacity);

            if (IsWithinCapacity(capacity, DefaultPositiveCapacity))
            {
                return false;
            }

            int doubleLength = InnerDoubleUnchecked(length);
            return IsWithinCapacity(doubleLength, capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerDoubleUnchecked(int value)
            =>
            value << 1; // unchecked(value * 2);
    }
}
