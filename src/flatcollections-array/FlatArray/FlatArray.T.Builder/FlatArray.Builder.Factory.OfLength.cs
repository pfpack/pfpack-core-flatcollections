namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder OfLength(int length)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            return new(length, capacity: length);
        }

        // TODO: Make public when dynamic builder is implemented
        internal static Builder OfLength(int length, int capacity)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            if (capacity >= length is not true)
            {
                throw InnerExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToLength(nameof(capacity), capacity, length: length);
            }

            return new(length, capacity: capacity);
        }
    }
}
