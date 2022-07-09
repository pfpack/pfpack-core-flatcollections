namespace System.Collections.Generic;

public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
{
    private readonly IEqualityComparer<T>? comparer;

    private IEqualityComparer<T> Comparer()
        =>
        comparer ?? EqualityComparer<T>.Default;

    public ArrayEqualityComparer() { }

    public ArrayEqualityComparer(IEqualityComparer<T>? comparer)
        =>
        this.comparer = comparer;

    public static ArrayEqualityComparer<T> Default
        =>
        DefaultInstance.Value;

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

        if (x.Length is not > 0)
        {
            return true;
        }

        var comparer = Comparer();

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
        // Return zero instead of throwing ArgumentNullException (the best practice)
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        if (obj.Length is not > 0)
        {
            return builder.ToHashCode();
        }

        var comparer = Comparer();

        for (int i = 0; i < obj.Length; i++)
        {
            var item = obj[i];
            builder.Add(item is not null ? comparer.GetHashCode(item) : default);
        }

        return builder.ToHashCode();
    }

    private static class DefaultInstance
    {
        internal static readonly ArrayEqualityComparer<T> Value = new();
    }
}
