namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal int EnsureCapacity(int capacity)
        {
            if (capacity is not >= 0)
            {
                throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(nameof(capacity), capacity);
            }

            if (items.Length < capacity)
            {
                Array.Resize(ref items, capacity);
            }

            return items.Length;
        }
    }
}
