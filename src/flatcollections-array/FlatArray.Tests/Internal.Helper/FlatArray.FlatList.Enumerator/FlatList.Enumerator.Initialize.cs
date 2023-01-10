using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static IEnumerator<T> InitializeFlatListEnumerator<T>(this T[] items, int length, int index)
    {
        var enumerator = items.InitializeFlatList(length).GetEnumerator();

        enumerator.SetFieldValue("length", length);
        enumerator.SetFieldValue("items", items);
        enumerator.SetFieldValue("index", index);

        return enumerator;
    }
}