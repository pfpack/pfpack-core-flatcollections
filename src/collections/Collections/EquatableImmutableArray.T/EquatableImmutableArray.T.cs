using System.Collections.Generic;

namespace System.Collections.Immutable;

public readonly partial struct EquatableImmutableArray<T> :
    IEquatable<EquatableImmutableArray<T>>,
    IReadOnlyList<T>,
    IList<T>
{
    private readonly ImmutableArray<T> items;

    internal EquatableImmutableArray(ImmutableArray<T> items)
        =>
        this.items = items;

    public T this[int index]
        =>
        items[index];

    public bool IsDefault
        =>
        items.IsDefault;

    public bool IsDefaultOrEmpty
        =>
        items.IsDefaultOrEmpty;

    public bool IsEmpty
        =>
        items.IsEmpty;

    public int Length
        =>
        items.Length;

    public ImmutableArray<T>.Enumerator GetEnumerator()
        =>
        items.GetEnumerator();

    private static NotSupportedException ReadOnlyNotSupportedException()
        =>
        new("The collection is read only.");
}
