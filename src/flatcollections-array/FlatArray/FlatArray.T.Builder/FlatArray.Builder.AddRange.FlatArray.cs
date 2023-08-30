using System.Runtime.CompilerServices;

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

            InnerAddRange(items.items!, items.length);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange(FlatArray<T> items, int length)
            =>
            InnerAddRangeChecked(items, length);

        // TODO: Add the tests and make public
        internal Builder AddRange(FlatArray<T>? items, int length)
            =>
            InnerAddRangeChecked(items.GetValueOrDefault(), length);

        private Builder InnerAddRangeChecked(
            FlatArray<T> items, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
        {
            if (InnerAllocHelper.IsWithinLength(length, items.length) is not true)
            {
                throw InnerExceptionFactory.StartSegmentOutsideBounds(lengthParamName, length, items.length);
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
