using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static IList<T> InitializeFlatList<T>(this T[] items, int? length = null)
        =>
        (IList<T>)items.InnerInitializeFlatList(length);

    internal static IReadOnlyList<T> InitializeFlatListAsReadOnly<T>(this T[] items, int? length = null)
        =>
        (IReadOnlyList<T>)items.InnerInitializeFlatList(length);

    private static IEnumerable<T> InnerInitializeFlatList<T>(this T[] items, int? length = null)
    {
        var source = default(FlatArray<T>).AsEnumerable();

        source.SetFieldValue("length", length ?? items.Length);
        source.SetFieldValue("items", items);

        return source;
    }
}