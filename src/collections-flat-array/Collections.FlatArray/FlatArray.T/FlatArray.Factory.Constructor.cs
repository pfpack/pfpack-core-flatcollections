using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    // Initializes an instance in 'as is' mode without any processing and creation of a defensive copy
    //
    // Since the invariant of FlatArray implies the empty FlatArray contains null underlying array,
    // the caller MUST ensure the items size is GREATER than zero
    //
    // Note: The unused arg is intended to separate this from the public one
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private FlatArray(T[] items, int _)
    {
        Debug.Assert(items.Length != default);

        length = items.Length;
        this.items = items;
    }
}
