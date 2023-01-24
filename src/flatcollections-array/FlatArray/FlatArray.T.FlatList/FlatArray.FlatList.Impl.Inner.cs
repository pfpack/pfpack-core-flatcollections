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
        private void InnerCopyTo(T[] array, int arrayIndex)
            =>
            Array.Copy(items, 0, array, arrayIndex, length); // Delegate null and range checks to Array.Copy

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerator<T> InnerGetEnumerator()
            =>
            new Enumerator(length, items);
    }
}
