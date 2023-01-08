using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static IList<T> CreateEmptyFlatList<T>()
        =>
        (IList<T>)InnerCreateEmptyFlatList<T>();

    internal static IReadOnlyList<T> CreateEmptyFlatListAsReadOnly<T>()
        =>
        (IReadOnlyList<T>)InnerCreateEmptyFlatList<T>();

    private static IEnumerable<T> InnerCreateEmptyFlatList<T>()
        =>
        default(FlatArray<T>).AsEnumerable();
}