using System.Collections.Generic;
using System.Collections.Immutable;

namespace System;

partial struct FlatArray<T>
{
    public T[] ToArray()
        =>
        length == default ? InnerEmptyArray.OuterValue : InnerArrayHelper.Copy(items!, length);

    public List<T> ToList()
    {
        if (length == default)
        {
            return new();
        }

        if (length == items!.Length)
        {
            return new(items);
        }

        // The most efficient way to build a list for this case:

        List<T> result = new(capacity: length);
        for (int i = 0; i < length; i++)
        {
            result.Add(items[i]);
        }
        return result;
    }

    public ImmutableArray<T> ToImmutableArray()
    {
        if (length == default)
        {
            return ImmutableArray<T>.Empty;
        }

        if (length == items!.Length)
        {
            return ImmutableArray.Create(items);
        }

        return ImmutableArray.Create(items, 0, length);
    }
}
