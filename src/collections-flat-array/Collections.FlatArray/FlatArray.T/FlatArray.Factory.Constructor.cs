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

    // Creates an instance without making a defensive copy
    //
    // Since the invariant of FlatArray implies the empty FlatArray contains null underlying array,
    // the caller MUST ensure the items size is GREATER than zero
    //
    // Note: The unused arg is intended to separate this from the public one
    private FlatArray(T[] items, int _)
    {
        Debug.Assert(items.Length != default);

        length = items.Length;
        this.items = items;
    }
}
