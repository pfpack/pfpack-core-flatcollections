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

            InnerAddRange(items);
            return this;
        }

        // TODO: Add the tests and make public
        internal Builder AddRange([AllowNull] T[] items, int length)
        {
            var actualLength = items?.Length ?? default;

            if (InnerAllocHelper.IsWithinLength(length, actualLength) is not true)
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
        private void InnerAddRange(T[] items)
        {
            InnerBufferHelperEx.EnsureBufferCapacity(ref this.items, length, items.Length);
            new ReadOnlySpan<T>(items).CopyTo(new Span<T>(this.items, length, items.Length));
            length += items.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerAddRange(T[] items, int length)
        {
            Debug.Assert(length >= 0 && length <= items.Length);

            InnerBufferHelperEx.EnsureBufferCapacity(ref this.items, this.length, length);
            new ReadOnlySpan<T>(items, 0, length).CopyTo(new Span<T>(this.items, this.length, length));
            this.length += length;
        }
    }
}
