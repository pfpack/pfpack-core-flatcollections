using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static IList<T> InitializeFlatList<T>(this T[] items, int? length = null)
    {
        var source = default(FlatArray<T>).AsEnumerable();

        source.SetFieldValue("length", length ?? items.Length);
        source.SetFieldValue("items", items);

        return (IList<T>)source;
    }
}