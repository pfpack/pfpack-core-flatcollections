using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Immutable;

partial struct EquatableImmutableArray<T>
{
    public static bool Equals(EquatableImmutableArray<T> left, EquatableImmutableArray<T> right)
        =>
        left.Equals(right);

    public static bool operator ==(EquatableImmutableArray<T> left, EquatableImmutableArray<T> right)
        =>
        left.Equals(right);

    public static bool operator !=(EquatableImmutableArray<T> left, EquatableImmutableArray<T> right)
        =>
        left.Equals(right) is false;

    public bool Equals(EquatableImmutableArray<T> other)
        =>
        ItemsEqualityComparer.Equals(items, other.items);

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is EquatableImmutableArray<T> other &&
        Equals(other);

    public override int GetHashCode()
        =>
        HashCode.Combine(
            EqualityContractComparer.GetHashCode(EqualityContract),
            ItemsEqualityComparer.GetHashCode(items));

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static Type EqualityContract
        =>
        typeof(EquatableImmutableArray<T>);

    private static ImmutableArrayEqualityComparer<T> ItemsEqualityComparer
        =>
        ImmutableArrayEqualityComparer<T>.Default;
}
