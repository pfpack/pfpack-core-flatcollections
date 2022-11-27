using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class TestHelper
{
    internal static FlatArray<T> CreateFlatArrayByInnerConstructor<T>(T[] sourceArray)
    {
        Debug.Assert(sourceArray.Length is not 0);

        // Use a boxed default array instance to modify its inner state next
        object array = default(FlatArray<T>);

        GetFlatArrayLengthFieldInfo<T>().SetValue(array, sourceArray.Length);
        GetFlatArrayItemsFieldInfo<T>().SetValue(array, sourceArray);

        return (FlatArray<T>)array;
    }
}