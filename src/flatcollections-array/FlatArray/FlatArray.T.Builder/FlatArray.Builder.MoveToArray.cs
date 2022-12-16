using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public FlatArray<T> MoveToArray()
            =>
            InnerMoveToArray();

        // TODO: Make public when dynamic builder is implemented
        internal FlatArray<T> MoveToArray(bool trimExcess)
        {
            if (trimExcess)
            {
                InnerTrimExcess();
            }

            return InnerMoveToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FlatArray<T> InnerMoveToArray()
        {
            // Copy the state to reduce the chance of multithreading side effects

            var length = this.length;
            var items = this.items;

            if (length == default)
            {
                return default;
            }

            this.length = default;
            this.items = InnerEmptyArray.Value;

            // Call the inner constructor of FlatArray here
            return new(length, items);
        }
    }
}
