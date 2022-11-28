namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal static Builder Empty()
            =>
            default;

        // TODO: Make public when dynamic builder is implemented
        internal static Builder Empty(int capacity)
        {
            if (capacity is not >= 0)
            {
                throw InnerExceptionFactory.CapacityOutOfRange(nameof(capacity), capacity);
            }

            // TODO: Implement dynamic builder
            throw new NotImplementedException();
        }
    }
}
