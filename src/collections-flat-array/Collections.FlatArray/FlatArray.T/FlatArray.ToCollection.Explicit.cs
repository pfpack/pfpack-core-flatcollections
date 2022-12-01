using System.Collections.Immutable;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public T[] ToArray()
        =>
        InnerIsNotEmpty ? InnerArrayHelper.Copy(items, length) : InnerEmptyArray.OuterValue;

    public List<T> ToList()
        =>
        InnerIsNotEmpty ? new(items) : new();

    public ImmutableArray<T> ToImmutableArray()
        =>
        InnerIsNotEmpty ? ImmutableArray.Create(items) : ImmutableArray<T>.Empty;
}
