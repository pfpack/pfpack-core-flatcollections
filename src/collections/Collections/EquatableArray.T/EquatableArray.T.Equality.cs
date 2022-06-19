namespace System.Collections.Generic;

partial class EquatableArray<T>
{
    public static bool Equals(EquatableArray<T>? left, EquatableArray<T>? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return ItemsEqualityComparer.Equals(left.items, right.items);
    }

    public static bool operator ==(EquatableArray<T>? left, EquatableArray<T>? right)
        =>
        Equals(left, right);

    public static bool operator !=(EquatableArray<T>? left, EquatableArray<T>? right)
        =>
        Equals(left, right) is false;

    public bool Equals(EquatableArray<T>? other)
        =>
        Equals(this, other);

    public override bool Equals(object? obj)
        =>
        obj is EquatableArray<T> other &&
        Equals(this, other);

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
        typeof(EquatableArray<T>);

    private static ArrayEqualityComparer<T> ItemsEqualityComparer
        =>
        ArrayEqualityComparer<T>.Default;
}
