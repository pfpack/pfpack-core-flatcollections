using System.Collections.Generic;
using System.Diagnostics;

namespace System;

partial struct FlatArray<T>
{
    private sealed partial class FlatList : IList<T>, IReadOnlyList<T>
    {
        private readonly int length;

        private readonly T[] items;

        internal FlatList(int length, T[] items)
        {
            Debug.Assert(length >= 0 && length <= items.Length);

            this.length = length;
            this.items = items;
        }
    }
}
