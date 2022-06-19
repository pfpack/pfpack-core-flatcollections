namespace System.Collections.Generic;

public sealed partial class EquatableArray<T> :
    IEquatable<EquatableArray<T>>,
    IReadOnlyList<T>,
    IList<T>
{
    private readonly T[] items;

    internal EquatableArray(T[] items)
        =>
        this.items = items;

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public int Length
        =>
        items.Length;

    private static NotSupportedException FixedSizeNotSupportedException()
        =>
        new("The collection is fixed size.");
}
