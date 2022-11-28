using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class TestHelper
{
    internal static FlatArray<T> Initialize<T>(T[] items, int? length = null)
    {
        Debug.Assert(items.Length is not 0);

        // Use a boxed default array instance to modify its inner state next
        object array = default(FlatArray<T>);

        GetFlatArrayLengthFieldInfo<T>().SetValue(array, length ?? items.Length);
        GetFlatArrayItemsFieldInfo<T>().SetValue(array, items);

        return (FlatArray<T>)array;
    }
}