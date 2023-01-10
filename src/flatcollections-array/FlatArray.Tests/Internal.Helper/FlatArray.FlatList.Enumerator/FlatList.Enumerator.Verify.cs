using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyFlatListEnumeratorState<T>(
        this IEnumerator<T> actual, int expectedLength, T[] expectedItems, int expectedIndex)
    {
        const string expectedTypeName = "Enumerator";
        var actualTypeName = actual.GetType().Name;
        Assert.Equal(expectedTypeName, actualTypeName);

        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]>("items");
        Assert.Equal(expectedItems, actualItems);

        var actualIndex = actual.GetStructFieldValue<int>("index");
        Assert.StrictEqual(expectedIndex, actualIndex);
    }
}