using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    private static class InnerAllocHelper
    {
        // The caller MUST ensure the length is GREATER than or EQUAL to zero
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsIndexInRange(int index, int length)
        {
            Debug.Assert(length >= 0);

            return unchecked((uint)index) < unchecked((uint)length);
        }

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

            int doubleLength = InnerDoubleLength(length);
            return InnerIsLengthWithinCapacity(doubleLength, maxCapacity) ? doubleLength : maxCapacity;
        }

        // The caller MUST ensure the length is GREATER than zero,
        // and the length is LESS than or EQUAL to the capacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsHugeCapacity(int length, int capacity)
        {
            Debug.Assert(length > 0);
            Debug.Assert(length <= capacity);

            int doubleLength = InnerDoubleLength(length);
            return InnerIsLengthWithinCapacity(doubleLength, capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int InnerDoubleLength(int length)
            =>
            length << 1; // unchecked(length * 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InnerIsLengthWithinCapacity(int length, int capacity)
            =>
            unchecked((uint)length) <= unchecked((uint)capacity);
    }
}
