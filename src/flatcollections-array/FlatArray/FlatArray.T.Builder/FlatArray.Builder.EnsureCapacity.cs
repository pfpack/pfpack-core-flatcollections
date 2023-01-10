namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal int EnsureCapacity(int capacity)
        {
            if (capacity is not >= 0)
            {
                throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            // Copy the state to reduce the chance of multithreading side effects

            var items = this.items;

            if (capacity <= items.Length)
            {
                return items.Length;
            }

            InnerArrayHelper.ExtendUnchecked(ref items, capacity);
            this.items = items;
            return capacity;
        }
    }
}
