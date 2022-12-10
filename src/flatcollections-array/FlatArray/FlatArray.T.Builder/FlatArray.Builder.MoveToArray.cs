using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
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
            if (InnerIsEmpty)
            {
                return default;
            }

            var copy = this;
            this = default;
            return new(copy.length, copy.items);
        }
    }
}
