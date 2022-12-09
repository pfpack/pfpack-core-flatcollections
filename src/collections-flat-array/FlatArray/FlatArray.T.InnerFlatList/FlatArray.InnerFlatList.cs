using System.Diagnostics;

namespace System;

partial struct FlatArray<T>
{
    private sealed partial class InnerFlatList : IList<T>, IReadOnlyList<T>
    {
        private readonly int length;

        private readonly T[] items;

        internal InnerFlatList(int length, T[] items)
        {
            Debug.Assert(length >= 0 && length <= items.Length);

            this.length = length;
            this.items = items;
        }
    }
}
