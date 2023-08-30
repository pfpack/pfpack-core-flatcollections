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
            =>
            Array.IndexOf(items, item, 0, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InnerCopyToChecked(
            T[] array,
            int arrayIndex,
            [CallerArgumentExpression(nameof(array))] string arrayParamName = "",
            [CallerArgumentExpression(nameof(arrayIndex))] string arrayIndexParamName = "")
        {
            _ = array ?? throw new ArgumentNullException(arrayParamName);

            InnerValidateRange();

            if (length == default)
            {
                return;
            }

            var sourceSpan = length == items.Length
                ? new ReadOnlySpan<T>(items)
                : new ReadOnlySpan<T>(items, 0, length);

            var destSpan = new Span<T>(array, arrayIndex, array.Length - arrayIndex);

            sourceSpan.CopyTo(destSpan);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void InnerValidateRange()
            {
                if (arrayIndex is not >= 0)
                {
                    throw InnerListExceptionFactory.CopyTo_ArrayIndexLessThanZero(arrayIndexParamName, arrayIndex);
                }

                if (InnerAllocHelper.IsSegmentWithinBounds(arrayIndex, length, array.Length) is not true)
                {
                    throw InnerListExceptionFactory.CopyTo_SourceOutsideDestBounds(length, arrayIndex, array.Length);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerator<T> InnerGetEnumerator()
            =>
            new Enumerator(length, items);
    }
}
