namespace System.Collections.Generic;

public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
{
    private readonly IEqualityComparer<T> comparer;

    private ArrayEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static ArrayEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static ArrayEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static ArrayEqualityComparer<T> Default
        =>
        InnerDefault.Value;

    public bool Equals(T[]? x, T[]? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Length != y.Length)
        {
            return false;
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (comparer.Equals(x[i], y[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(T[] obj)
    {
        // Return zero instead of throwing ArgumentNullException
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        for (int i = 0; i < obj.Length; i++)
        {
            var item = obj[i];
            builder.Add(item is null ? default : comparer.GetHashCode(item));
        }

        return builder.ToHashCode();
    }

    private static class InnerDefault
    {
        internal static readonly ArrayEqualityComparer<T> Value = Create();
    }
}
