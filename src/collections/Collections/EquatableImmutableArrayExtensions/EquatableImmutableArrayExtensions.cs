namespace System.Collections.Immutable;

public static class EquatableImmutableArrayExtensions
{
    public static EquatableImmutableArray<T> AsEquatableImmutableArray<T>(this ImmutableArray<T> items)
        =>
        new(items);
}
