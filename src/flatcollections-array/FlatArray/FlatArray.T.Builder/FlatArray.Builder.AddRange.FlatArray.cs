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
            InternalAddRangeChecked(items, length);

        // TODO: Add the tests and make public
        internal Builder AddRange(FlatArray<T>? items, int length)
            =>
            InternalAddRangeChecked(items.GetValueOrDefault(), length);

        internal Builder InternalAddRangeChecked(
            FlatArray<T> items, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
        {
            if (InnerAllocHelper.IsWithin(length, items.length) is not true)
            {
                throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(lengthParamName, length, items.length);
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
