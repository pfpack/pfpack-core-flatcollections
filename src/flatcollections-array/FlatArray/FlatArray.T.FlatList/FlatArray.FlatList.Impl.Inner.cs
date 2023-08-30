using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InnerItemChecked(int index)
        {
            if (InnerAllocHelper.IsIndexInRange(index, length))
            {
                return items[index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(index, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int InnerIndexOf(T item)
        {
            var result = Array.IndexOf(items, item, 0, length);
            return result >= 0 ? result : MinusOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerCopyToChecked(
            T[] array,
            int arrayIndex,
            [CallerArgumentExpression(nameof(array))] string arrayParamName = "",
            [CallerArgumentExpression(nameof(arrayIndex))] string arrayIndexParamName = "")
        {
            if (array is null)
            {
                throw new ArgumentNullException(arrayParamName);
            }
            if (arrayIndex is not >= 0)
            {
                throw InnerListExceptionFactory.CopyTo_ArrayIndexLessThanZero(arrayIndexParamName, arrayIndex);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerator<T> InnerGetEnumerator()
            =>
            new Enumerator(length, items);
    }
}
