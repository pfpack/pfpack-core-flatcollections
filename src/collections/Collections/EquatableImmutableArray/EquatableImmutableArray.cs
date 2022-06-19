namespace System.Collections.Immutable;

public static class EquatableImmutableArray
{
    public static EquatableImmutableArray<T> From<T>(ImmutableArray<T> items)
        =>
        new(items);

    public static bool Equals<T>(EquatableImmutableArray<T> left, EquatableImmutableArray<T> right)
        =>
        left.Equals(right);
}
