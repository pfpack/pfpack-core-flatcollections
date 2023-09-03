using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder AddRange(ImmutableArray<T> items)
        {
            if (items.IsDefaultOrEmpty)
            {
                return this;
            }

            InnerAddRange(items, items.Length);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange(ImmutableArray<T> items, int length)
            =>
            InnerAddRangeChecked(items, length);

        // TODO: Add the tests and make public
        internal Builder AddRange(ImmutableArray<T>? items, int length)
            =>
            InnerAddRangeChecked(items.GetValueOrDefault(), length);

        private Builder InnerAddRangeChecked(
            ImmutableArray<T> items, int length, [CallerArgumentExpression(nameof(length))] string lengthParamName = "")
        {
            var itemsLength = items.IsDefault ? default : items.Length;

            if (InnerAllocHelper.IsStartSegmentWithinBounds(length, itemsLength) is not true)
            {
                throw InnerExceptionFactory.StartSegmentOutsideBounds(lengthParamName, length, itemsLength);
            }

            if (items.IsDefaultOrEmpty)
            {
                return this;
            }

            InnerAddRange(items, length);
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerAddRange(ImmutableArray<T> items, int length)
        {
            Debug.Assert(items.IsDefaultOrEmpty is false);
            Debug.Assert(length > 0 && length <= items.Length);

            InnerBufferHelperEx.EnsureBufferCapacity(ref this.items, this.length, length);
            items.CopyTo(0, this.items, this.length, length);
            this.length += length;
        }
    }
}
