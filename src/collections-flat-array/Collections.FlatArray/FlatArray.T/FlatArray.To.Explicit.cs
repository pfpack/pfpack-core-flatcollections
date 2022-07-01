using System.Collections.Immutable;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T[] ToArray()
        =>
        items.Length > 0 ? InnerCloneArray(items) : Array.Empty<T>();

    public List<T> ToList()
        =>
        // Clone for the safety purposes
        items.Length > 0 ? new(InnerCloneArray(items)) : new();

    public ImmutableArray<T> ToImmutableArray()
        =>
        items.Length > 0 ? ImmutableArray.Create(items) : ImmutableArray<T>.Empty;
}
