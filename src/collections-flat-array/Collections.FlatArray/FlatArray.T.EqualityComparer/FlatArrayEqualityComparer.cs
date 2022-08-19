namespace System.Collections.Generic;

public sealed class FlatArrayEqualityComparer<T> : IEqualityComparer<FlatArray<T>>
{
    private readonly IEqualityComparer<T> comparer;

    private FlatArrayEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static FlatArrayEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static FlatArrayEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static FlatArrayEqualityComparer<T> Default
        =>
        DefaultInstance.Value;

    public bool Equals(FlatArray<T>? x, FlatArray<T>? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (FlatArray<T>.InternalItemsSame(x, y))
        {
            return true;
        }

        if (x.Length != y.Length)
        {
            return false;
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (comparer.Equals(x.InternalItem(i), y.InternalItem(i)))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(FlatArray<T> obj)
    {
        // Return zero instead of throwing ArgumentNullException
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        for (int i = 0; i < obj.Length; i++)
        {
            var item = obj.InternalItem(i);
            builder.Add(item is not null ? comparer.GetHashCode(item) : default);
        }

        return builder.ToHashCode();
    }

    private static class DefaultInstance
    {
        internal static readonly FlatArrayEqualityComparer<T> Value = Create();
    }
}
