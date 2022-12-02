using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayEqualityComparerTest
{
    public enum DefaultComparerFactory
    {
        Default,

        Create,

        CreateWithNull
    }

    private static FlatArray<T>.EqualityComparer CreateComparerWithDefaultItemComparer<T>(DefaultComparerFactory comparerFactory)
        =>
        comparerFactory switch
        {
            DefaultComparerFactory.Create => FlatArray<T>.EqualityComparer.Create(),
            DefaultComparerFactory.CreateWithNull => FlatArray<T>.EqualityComparer.Create(null),
            _ => FlatArray<T>.EqualityComparer.Default
        };
}