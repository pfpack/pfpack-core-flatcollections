using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

public sealed class ReadOnlyListEqualityComparer<T> : IEqualityComparer<IReadOnlyList<T>>
{
    private readonly IEqualityComparer<T>? comparer;

    private IEqualityComparer<T> Comparer()
        =>
        comparer ?? EqualityComparer<T>.Default;

    public ReadOnlyListEqualityComparer() { }

    public ReadOnlyListEqualityComparer(IEqualityComparer<T>? comparer)
        =>
        this.comparer = comparer;

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

        if (x.Count is not > 0)
        {
            return true;
        }

        var comparer = Comparer();

        for (int i = 0; i < x.Count; i++)
        {
            if (comparer.Equals(x[i], y[i]) is false)
            {
                return false;
            }
        }

        return true;
    }

    public int GetHashCode([DisallowNull] IReadOnlyList<T> obj)
    {
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        builder.Add(obj.Count);

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
        internal static readonly ReadOnlyListEqualityComparer<T> Value = new();
    }
}
