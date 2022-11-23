namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    private sealed partial class InnerFlatList : IList<T>, IReadOnlyList<T>
    {
        private readonly T[] items;

        internal InnerFlatList(T[] items) => this.items = items;
    }
}
