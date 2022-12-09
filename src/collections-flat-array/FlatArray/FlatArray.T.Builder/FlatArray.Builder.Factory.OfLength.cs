namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder OfLength(int length)
        {
            if (length is not >= 0)
            {
                throw InnerExceptionFactory.LengthOutOfRange(nameof(length), length);
            }

            return length == default ? default : new(new T[length], default);
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

            // TODO: Implement dynamic builder
            throw new NotImplementedException();
        }
    }
}
