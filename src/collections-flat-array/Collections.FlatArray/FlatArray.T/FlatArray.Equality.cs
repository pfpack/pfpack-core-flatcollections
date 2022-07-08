namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public bool Equals(FlatArray<T>? other)
        =>
        Equals(this, other);

    public override bool Equals(object? obj)
        =>
        obj is FlatArray<T> other &&
        Equals(this, other);

    public static bool operator ==(FlatArray<T>? left, FlatArray<T>? right)
        =>
        Equals(left, right);

    public static bool operator !=(FlatArray<T>? left, FlatArray<T>? right)
        =>
        Equals(left, right) is false;

    public static bool Equals(FlatArray<T>? left, FlatArray<T>? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        if (ReferenceEquals(left.items, right.items))
        {
            return true;
        }

        if (left.items.Length != right.items.Length)
        {
            return false;
        }

        if (left.items.Length is not > 0)
        {
            return true;
        }

        var itemComparer = ItemComparer();

        for (int i = 0; i < left.items.Length; i++)
        {
            if (itemComparer.Equals(left.items[i], right.items[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        HashCode builder = new();

        builder.Add(EqualityContractComparer.GetHashCode(EqualityContract));

        if (items.Length is not > 0)
        {
            return builder.GetHashCode();
        }

        var itemComparer = ItemComparer();

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            builder.Add(item is not null ? itemComparer.GetHashCode(item) : default);
        }

        return builder.ToHashCode();
    }

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static Type EqualityContract
        =>
        typeof(FlatArray<T>);

    private static EqualityComparer<T> ItemComparer()
        =>
        EqualityComparer<T>.Default;
}
