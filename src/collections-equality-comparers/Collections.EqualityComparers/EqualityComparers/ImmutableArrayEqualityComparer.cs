using System.Collections.Generic;

namespace System.Collections.Immutable;

public sealed class ImmutableArrayEqualityComparer<T> : IEqualityComparer<ImmutableArray<T>>
{
    private readonly IEqualityComparer<T> comparer;

    private ImmutableArrayEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static ImmutableArrayEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static ImmutableArrayEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static ImmutableArrayEqualityComparer<T> Default
        =>
        InnerDefault.Value;

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
        // Return zero instead of throwing ArgumentNullException
        if (obj.IsDefault)
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
        internal static readonly ImmutableArrayEqualityComparer<T> Value = Create();
    }
}
