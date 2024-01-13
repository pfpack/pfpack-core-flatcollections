using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder AddRange([AllowNull] List<T> items)
        {
            if (items is null || items.Count == default)
            {
                return this;
            }

            InnerAddRange(items, items.Count);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange([AllowNull] List<T> items, int length)
        {
            var itemsLength = items?.Count ?? default;

            if (InnerAllocHelper.IsStartSegmentWithinBounds(length, itemsLength) is not true)
            {
                throw InnerExceptionFactory.StartSegmentOutsideBounds(nameof(length), length, itemsLength);
            }

            if (items is null || items.Count == default)
            {
                return this;
            }

            InnerAddRange(items, length);
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerAddRange(List<T> items, int length)
        {
            Debug.Assert(items.Count != default);
            Debug.Assert(length > 0 && length <= items.Count);

            InnerBuilderBufferHelper.EnsureBufferCapacity(ref this.items, this.length, length);
            items.CopyTo(0, this.items, this.length, length);
            this.length += length;
        }
    }
}
