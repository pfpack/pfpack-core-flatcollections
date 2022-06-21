using System.Collections.Generic;

namespace System.Collections.Immutable;

public sealed partial class FlatArray<T> : IReadOnlyList<T>, IEquatable<FlatArray<T>>
{
    private readonly T[] items;

    public int Length
        =>
        items.Length;

    int IReadOnlyCollection<T>.Count
        =>
        items.Length;

    public static FlatArray<T> Empty
        =>
        InnerEmptyFlatArray.Value;
}
