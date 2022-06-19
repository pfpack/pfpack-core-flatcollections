namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    public static EquatableImmutableArray<T> From(ImmutableArray<T> items)
        =>
        new(items);

    public static implicit operator EquatableImmutableArray<T>(ImmutableArray<T> items)
        =>
        new(items);
}
