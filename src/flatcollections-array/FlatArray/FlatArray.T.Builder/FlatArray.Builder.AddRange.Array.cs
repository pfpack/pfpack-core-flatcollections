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
            var actualLength = items?.Length ?? default;

            if (InnerAllocHelper.IsWithinCapacity(length, actualLength) is not true)
            {
                throw InnerBuilderExceptionFactory.StartSegmentLengthOutOfArrayLength(nameof(length), length, actualLength);
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
            InnerBufferHelperEx.EnsureBufferCapacity(ref this.items, this.length, length);
            var span = new Span<T>(this.items, this.length, length);
            new ReadOnlySpan<T>(items).CopyTo(span);
            this.length += length;
        }
    }
}
