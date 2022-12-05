using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerFlatListEnumeratorState<T>(
        this IEnumerator<T> actual, T[] expectedItems, int expectedLength, int expectedIndex)
    {
        var actualTypeName = actual.GetType().Name;
        const string expectedTypeName = "InnerEnumerator";

        Assert.Equal(expectedTypeName, actualTypeName);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);

        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualIndex = actual.GetStructFieldValue<int>("index");
        Assert.StrictEqual(expectedIndex, actualIndex);
    }
}