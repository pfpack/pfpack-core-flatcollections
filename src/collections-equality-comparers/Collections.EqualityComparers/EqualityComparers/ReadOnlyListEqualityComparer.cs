namespace System.Collections.Generic;

public sealed class ReadOnlyListEqualityComparer<T> : IEqualityComparer<IReadOnlyList<T>>
{
    private readonly IEqualityComparer<T> comparer;

    private ReadOnlyListEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static ReadOnlyListEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static ReadOnlyListEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static ReadOnlyListEqualityComparer<T> Default
        =>
        DefaultInstance.Value;

    public bool Equals(IReadOnlyList<T>? x, IReadOnlyList<T>? y)
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

    public int GetHashCode(IReadOnlyList<T> obj)
    {
        // Return zero instead of throwing ArgumentNullException
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        for (int i = 0; i < obj.Count; i++)
        {
            var item = obj[i];
            builder.Add(item is not null ? comparer.GetHashCode(item) : default);
        }

        return builder.ToHashCode();
    }

    private static class DefaultInstance
    {
        internal static readonly ReadOnlyListEqualityComparer<T> Value = Create();
    }
}
