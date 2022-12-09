using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static IEnumerator<T> InitializeFlatListEnumerator<T>(this T[] items, int length, int index)
    {
        var flatListEnumerator = items.InitializeFlatList(length).GetEnumerator();

        flatListEnumerator.SetFieldValue("items", items);
        flatListEnumerator.SetFieldValue("length", length);
        flatListEnumerator.SetFieldValue("index", index);

        return flatListEnumerator;
    }
}