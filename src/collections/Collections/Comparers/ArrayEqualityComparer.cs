using System.Diagnostics.CodeAnalysis;

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

        if (x.Length > 0)
        {
            var comparer = Comparer();

            for (int i = 0; i < x.Length; i++)
            {
                if (comparer.Equals(x[i], y[i]) is false)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public int GetHashCode([DisallowNull] T[] obj)
    {
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        builder.Add(obj.Length);

        if (obj.Length > 0)
        {
            var comparer = Comparer();

            for (int i = 0; i < obj.Length; i++)
            {
                var item = obj[i];
                builder.Add(item is not null ? comparer.GetHashCode(item) : default);
            }
        }

        return builder.ToHashCode();
    }

    private static class DefaultInstance
    {
        internal static readonly ArrayEqualityComparer<T> Value = new();
    }
}
