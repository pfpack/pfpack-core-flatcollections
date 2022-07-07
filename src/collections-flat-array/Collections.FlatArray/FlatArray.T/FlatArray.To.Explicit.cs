using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T[] ToArray()
        =>
        items.Length > 0 ? InnerArrayHelper.Clone(items) : Array.Empty<T>();

    public List<T> ToList()
        =>
        items.Length > 0 ? new(items) : new();

    public ImmutableArray<T> ToImmutableArray()
        =>
        items.Length > 0 ? ImmutableArray.Create(items) : ImmutableArray<T>.Empty;
}
