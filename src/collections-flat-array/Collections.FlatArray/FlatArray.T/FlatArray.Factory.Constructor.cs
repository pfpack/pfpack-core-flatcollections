using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public FlatArray()
        =>
        items = InnerEmptyArray.Value;

    public FlatArray([AllowNull] params T[] source)
        =>
        items = source?.Length > 0 ? InnerArrayHelper.Clone(source) : InnerEmptyArray.Value;

    // Creates an instance in raw mode
    // The unused arg is intended to separate this from the public one
    private FlatArray(T[] items, int _)
        =>
        this.items = items;
}
