namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    public ImmutableArray<T> AsImmutableArray()
        =>
        items;

    public static implicit operator ImmutableArray<T>(EquatableImmutableArray<T> array)
        =>
        array.items;
}
