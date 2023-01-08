using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyFlatListState<T>(this IEnumerable<T> actual, T[] expectedItems, int expectedLength)
    {
        var actualTypeName = actual.GetType().Name;
        const string expectedTypeName = "FlatList";

        Assert.Equal(expectedTypeName, actualTypeName);

        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);
    }
}