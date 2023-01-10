using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class FlatList
    {
        bool ICollection<T>.IsReadOnly => true;

        T IList<T>.this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InnerItem(index); // Delegate range check to InnerItem
            set => throw InnerListExceptionFactory.NotSupportedOnReadOnlyArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
            =>
            InnerGetEnumerator();
    }
}
