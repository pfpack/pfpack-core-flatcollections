using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerFlatListState<T>(this IEnumerable<T> actual, int expectedLength, T[] expectedItems)
    {
        var actualTypeName = actual.GetType().Name;
        const string expectedTypeName = "InnerFlatList";

        Assert.Equal(expectedTypeName, actualTypeName);

        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);
    }
}