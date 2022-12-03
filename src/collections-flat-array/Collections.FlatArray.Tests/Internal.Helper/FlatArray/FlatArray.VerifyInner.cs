using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T> actual, int expectedLength, T[] expectedItems)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);
    }
}