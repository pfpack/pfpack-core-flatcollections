using System;
using System.Diagnostics;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T> InitializeFlatArray<T>(this T[] items, int? length = null)
    {
        Debug.Assert(items.Length is not 0);

        // Use a boxed default array instance to modify its inner state next
        object array = default(FlatArray<T>);

        array.SetFieldValue("length", length ?? items.Length);
        array.SetFieldValue("items", items);

        return (FlatArray<T>)array;
    }
}