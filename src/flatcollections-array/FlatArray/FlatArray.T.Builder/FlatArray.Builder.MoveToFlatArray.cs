using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public FlatArray<T> MoveToFlatArray()
            =>
            InnerMoveToFlatArray(false);

        // TODO: Make public when dynamic builder is implemented
        internal FlatArray<T> MoveToFlatArray(bool trimExcess)
            =>
            InnerMoveToFlatArray(trimExcess);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FlatArray<T> InnerMoveToFlatArray(bool trimExcess)
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

            if (trimExcess && length != items.Length || InnerAllocHelper.IsHugeCapacity(length, items.Length))
            {
                InnerArrayHelper.TruncateUnchecked(ref items, length);
            }

            // Call the inner constructor of FlatArray here
            return new(length, items);
        }
    }
}
