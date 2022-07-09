namespace System.Collections.Generic;

public sealed class ListEqualityComparer<T> : IEqualityComparer<IList<T>>
{
    private readonly IEqualityComparer<T>? comparer;

    private IEqualityComparer<T> Comparer()
        =>
        comparer ?? EqualityComparer<T>.Default;

    public ListEqualityComparer() { }

    public ListEqualityComparer(IEqualityComparer<T>? comparer)
        =>
        this.comparer = comparer;

    public static ListEqualityComparer<T> Default
        =>
        DefaultInstance.Value;

    public bool Equals(IList<T>? x, IList<T>? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        if (x.Count is not > 0)
        {
            return true;
        }

        var comparer = Comparer();

        for (int i = 0; i < x.Count; i++)
        {
            if (comparer.Equals(x[i], y[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(IList<T> obj)
    {
        // Return zero instead of throwing ArgumentNullException (the best practice)
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        // Make difference between null and empty collections
        builder.Add(0);

        if (obj.Count is not > 0)
        {
            return builder.ToHashCode();
        }

        var comparer = Comparer();

        for (int i = 0; i < obj.Count; i++)
        {
            var item = obj[i];
            builder.Add(item is not null ? comparer.GetHashCode(item) : default);
        }

        return builder.ToHashCode();
    }

    private static class DefaultInstance
    {
        internal static readonly ListEqualityComparer<T> Value = new();
    }
}
