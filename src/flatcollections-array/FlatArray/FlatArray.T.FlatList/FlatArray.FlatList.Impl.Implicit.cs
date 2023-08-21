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
            get => InnerItemChecked(index);
        }

        public int IndexOf(T item)
            =>
            length != default ? InnerIndexOf(item) : -1;

        public bool Contains(T item)
            =>
            length != default && InnerIndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
            =>
            InnerCopyToChecked(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
            =>
            InnerGetEnumerator();
    }
}
