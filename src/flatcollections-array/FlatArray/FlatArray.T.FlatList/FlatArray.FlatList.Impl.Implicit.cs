﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        private const int NotFoundIndex = -1;

        public int Count => length;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (InnerAllocHelper.IsIndexInRange(index, length))
                {
                    return items[index];
                }

                throw InnerExceptionFactory.IndexOutOfRange(index, length);
            }
        }

        public int IndexOf(T item)
            =>
            length != default ? InnerIndexOf(item) : NotFoundIndex;

        public bool Contains(T item)
            =>
            length != default && InnerIndexOf(item) != NotFoundIndex;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex is not >= 0)
            {
                throw InnerListExceptionFactory.CopyTo_ArrayIndexLessThanZero(nameof(arrayIndex), arrayIndex);
            }
            if (InnerAllocHelper.IsSegmentWithinBounds(arrayIndex, length, array.Length) is not true)
            {
                throw InnerListExceptionFactory.CopyTo_SourceOutsideDestBounds(length, arrayIndex, array.Length);
            }

            if (length == default)
            {
                return;
            }

            var sourceSpan = length == items.Length
                ? new ReadOnlySpan<T>(items)
                : new ReadOnlySpan<T>(items, 0, length);

            var destSpan = arrayIndex == default && length == array.Length
                ? new Span<T>(array)
                : new Span<T>(array, arrayIndex, length);

            sourceSpan.CopyTo(destSpan);
        }

        public IEnumerator<T> GetEnumerator()
            =>
            new Enumerator(length, items);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int InnerIndexOf(T item)
        {
            var result = Array.IndexOf(items, item, 0, length);
            return result >= 0 ? result : NotFoundIndex;
        }
    }
}
