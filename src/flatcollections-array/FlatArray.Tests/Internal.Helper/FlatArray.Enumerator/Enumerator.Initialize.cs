using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Enumerator InitializeFlatArrayEnumerator<T>(this T[] items, int length, int index)
    {
        // Use a boxed default enumerator instance to modify its inner state next
        object enumerator = default(FlatArray<T>.Enumerator);

        enumerator.SetFieldValue("length", length);
        enumerator.SetFieldValue("items", items);
        enumerator.SetFieldValue("index", index);

        return (FlatArray<T>.Enumerator)enumerator;
    }
}