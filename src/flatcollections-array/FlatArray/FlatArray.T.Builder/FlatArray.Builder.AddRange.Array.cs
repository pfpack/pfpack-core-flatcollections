﻿using System.Diagnostics;
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

            if (InnerAllocHelper.IsWithin(length, actualLength) is not true)
            {
                throw InnerExceptionFactory.StartSegmentLengthOutOfArrayLength(nameof(length), length, actualLength);
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

            InnerBufferHelperEx.EnsureBufferCapacity(ref this.items, this.length, length);
            var sourceSpan = length == items.Length
                ? new ReadOnlySpan<T>(items)
                : new ReadOnlySpan<T>(items, 0, length);
            sourceSpan.CopyTo(new Span<T>(this.items, this.length, length));
            this.length += length;
        }
    }
}
