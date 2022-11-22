namespace System.Collections.Generic;

internal sealed partial class FlatList<T> : IList<T>, IReadOnlyList<T>
{
    private readonly T[] items;

    internal FlatList(T[] items) => this.items = items;
}
