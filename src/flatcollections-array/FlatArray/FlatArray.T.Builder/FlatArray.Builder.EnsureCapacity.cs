using System.Diagnostics;

namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal int EnsureCapacity(int capacity)
        {
            Debug.Assert(InnerIsValidState());

            if (capacity is not >= 0)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            var copy = this;

            if (capacity == default)
            {
                return copy.items is null ? default : copy.items.Length;
            }

            if (copy.items is null)
            {
                copy.items = new T[capacity];
                this = copy;
                return capacity;
            }

            if (copy.items.Length < capacity)
            {
                InnerArrayHelper.ExtendUnchecked(ref copy.items, capacity);
                this = copy;
                return capacity;
            }

            return copy.items.Length;
        }
    }
}
