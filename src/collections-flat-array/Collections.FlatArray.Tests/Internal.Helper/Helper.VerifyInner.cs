using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(int expectedLength, T[] expectedItems, FlatArray<T> actual)
    {
        var actualLength = actual.GetInnerLength();
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetInnerItems();
        Assert.Equal(expectedItems, actualItems);
    }
}