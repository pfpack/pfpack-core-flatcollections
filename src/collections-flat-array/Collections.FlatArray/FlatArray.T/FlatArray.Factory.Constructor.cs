using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public FlatArray([AllowNull] params T[] source)
    {
        if (source is null || source.Length == default)
        {
            this = default;
            return;
        }

        length = source.Length;
        items = InnerArrayHelper.Clone(source);
    }

    // Creates an instance in raw mode
    // The caller MUST ensure the items size is GREATER than zero
    // The unused arg is intended to separate this from the public one
    private FlatArray(T[] items, int _)
    {
        Debug.Assert(items.Length != default);

        length = items.Length;
        this.items = items;
    }
}
