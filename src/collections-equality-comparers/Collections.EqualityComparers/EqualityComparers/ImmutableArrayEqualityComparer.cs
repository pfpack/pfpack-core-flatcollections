using System.Collections.Generic;

namespace System.Collections.Immutable;

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
        // ImmutableArray 'reference' equality
        if (x.Equals(y))
        {
            return true;
        }

        // Redundant since the 'reference' equality check is already done
        // Keep for safety purposes to avoid possible NullReferenceException
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
            if (comparer.Equals(x[i], y[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(ImmutableArray<T> obj)
    {
        // Return zero instead of throwing ArgumentNullException (the best practice)
        if (obj.IsDefault)
        {
            return default;
        }

        HashCode builder = new();

        // Make difference between null and empty collections
        builder.Add(0);

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
