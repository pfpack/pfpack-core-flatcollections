namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal int Capacity
        {
            get => items.Length;

            set
            {
                if (InnerAllocHelper.IsWithin(length, value) is not true)
                {
                    throw InnerBuilderExceptionFactory.CapacityOutOfRange_MustBeGreaterThanOrEqualToLength(value, length);
                }

                if (value == items.Length)
                {
                    return;
                }

                if (value == default)
                {
                    items = InnerEmptyArray.Value;
                }

                Array.Resize(ref items, value);
            }
        }
    }
}
