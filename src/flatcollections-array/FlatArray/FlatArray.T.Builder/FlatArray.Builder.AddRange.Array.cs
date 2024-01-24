using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal Builder AddRange([AllowNull] params T[] items)
        {
            if (items is null || items.Length == default)
            {
                return this;
            }

            InnerAddRange(items, items.Length);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange([AllowNull] T[] items, int length)
        {
            var itemsLength = items?.Length ?? default;

            if (InnerAllocHelper.IsStartSegmentWithinBounds(length, itemsLength) is not true)
            {
                throw InnerExceptionFactory.StartSegmentOutsideBounds(nameof(length), length, itemsLength);
            }

            if (items is null || items.Length == default)
            {
                return this;
            }

            InnerAddRange(items, length);
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerAddRange(T[] items, int length)
        {
            Debug.Assert(items.Length != default);
            Debug.Assert(length > 0 && length <= items.Length);

            InnerBuilderBufferHelper.EnsureBufferCapacity(ref this.items, this.length, length);

            ReadOnlySpan<T> sourceSpan = length == items.Length
                ? new(items)
                : new(items, 0, length);

            sourceSpan.CopyTo(new Span<T>(this.items, this.length, length));

            this.length += length;
        }
    }
}
