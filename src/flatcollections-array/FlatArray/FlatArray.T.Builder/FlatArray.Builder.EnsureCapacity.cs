namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal int EnsureCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            // Copy the state to reduce the chance of multithreading side effects

            var items = this.items;

            if (capacity <= items.Length)
            {
                return items.Length;
            }

            Array.Resize(ref items, capacity);
            this.items = items;
            return capacity;
        }
    }
}
