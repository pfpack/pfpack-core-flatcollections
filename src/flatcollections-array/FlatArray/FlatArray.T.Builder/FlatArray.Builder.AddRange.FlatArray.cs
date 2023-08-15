namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder AddRange(FlatArray<T> items)
        {
            if (items.length == default)
            {
                return this;
            }

            InnerAddRange(items, items.length);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange(FlatArray<T> items, int length)
        {
            if (InnerAllocHelper.IsWithinCapacity(length, items.length) is not true)
            {
                throw InnerBuilderExceptionFactory.StartSegmentLengthOutOfArrayLength(nameof(length), length, items.length);
            }

            if (items.length == default)
            {
                return this;
            }

            InnerAddRange(items.items!, length);
            return this;
        }
    }
}
