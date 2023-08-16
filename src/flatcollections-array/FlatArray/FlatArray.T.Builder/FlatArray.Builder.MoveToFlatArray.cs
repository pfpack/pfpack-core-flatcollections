using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public FlatArray<T> MoveToFlatArray()
            =>
            InnerMoveToFlatArray(false);

        // TODO: Add the tests and make public
        internal FlatArray<T> MoveToFlatArray(bool trimExcess)
            =>
            InnerMoveToFlatArray(trimExcess);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FlatArray<T> InnerMoveToFlatArray(bool trimExcess)
        {
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
                Array.Resize(ref items, length);
            }

            return new(length, items);
        }
    }
}
