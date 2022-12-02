using System.Collections.Immutable;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public T[] ToArray()
        =>
        InnerIsNotEmpty ? InnerArrayHelper.Copy(items, length) : InnerEmptyArray.OuterValue;

    public List<T> ToList()
    {
        if (InnerIsEmpty)
        {
            return new();
        }

        if (length < items.Length)
        {
            return new(InnerArrayHelper.Copy(items, length));
        }

        return new(items);
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (InnerIsEmpty)
        {
            return ImmutableArray<T>.Empty;
        }

        if (length < items.Length)
        {
            return ImmutableArray.Create(InnerArrayHelper.Copy(items, length));
        }

        return ImmutableArray.Create(items);
    }
}
