using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public FlatArray<T> MoveToArray()
            =>
            InnerMoveToArray(false);

        // TODO: Make public when dynamic builder is implemented
        internal FlatArray<T> MoveToArray(bool trimExcess)
            =>
            InnerMoveToArray(trimExcess);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FlatArray<T> InnerMoveToArray(bool trimExcess)
        {
            // Copy the state to reduce the chance of multithreading side effects

            var length = this.length;
            var items = this.items;

            this.length = default;
            this.items = InnerEmptyArray.Value;

            if (length == default)
            {
                return default;
            }

            if (trimExcess && length != items.Length || InnerIsHugeCapacity(length, items.Length))
            {
                InnerArrayHelper.TruncateUnchecked(ref items, length);
            }

            // Call the inner constructor of FlatArray here
            return new(length, items);
        }

        // The caller MUST ensure the length is GREATER than zero
        // and the capacity is NOT LESS than the length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InnerIsHugeCapacity(int length, int capacity)
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
