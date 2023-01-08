using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        public int Count => length;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InnerItem(index); // Delegate range check to InnerItem
        }

        public int IndexOf(T item)
            =>
            InnerIndexOf(item);

        public bool Contains(T item)
            =>
            InnerIndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
            =>
            InnerCopyTo(array, arrayIndex); // Delegate null and range checks to InnerCopyTo

        public IEnumerator<T> GetEnumerator()
            =>
            InnerGetEnumerator();
    }
}
