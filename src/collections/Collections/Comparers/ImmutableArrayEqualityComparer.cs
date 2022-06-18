using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

public sealed class ImmutableArrayEqualityComparer<T> : IEqualityComparer<ImmutableArray<T>>
{
    private readonly IEqualityComparer<T>? comparer;

    private IEqualityComparer<T> Comparer()
        =>
        comparer ?? EqualityComparer<T>.Default;

    public ImmutableArrayEqualityComparer() { }

    public ImmutableArrayEqualityComparer(IEqualityComparer<T>? comparer)
        =>
        this.comparer = comparer;

    public static ImmutableArrayEqualityComparer<T> Default
        =>
        DefaultInstance.Value;

    public bool Equals(ImmutableArray<T> x, ImmutableArray<T> y)
    {
        if (x.IsDefault && y.IsDefault)
        {
            return true;
        }

        if (x.IsDefault || y.IsDefault)
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
            if (comparer.Equals(x[i], y[i]) is false)
            {
                return false;
            }
        }

        return true;
    }

    public int GetHashCode([DisallowNull] ImmutableArray<T> obj)
    {
        if (obj.IsDefault)
        {
            return default;
        }

        HashCode builder = new();

        builder.Add(obj.Length);

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
        internal static readonly ImmutableArrayEqualityComparer<T> Value = new();
    }
}
