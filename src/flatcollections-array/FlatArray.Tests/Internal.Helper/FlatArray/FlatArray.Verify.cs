using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T> actual, T[]? expectedItems, int expectedLength)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);
    }

    internal static void VerifyTruncatedState<T>(this FlatArray<T> actual, params T[] expectedItems)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedItems.Length, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        if (actualItems is null || actualItems.Length == actualLength)
        {
            Assert.Equal(expectedItems, actualItems);
            return;
        }

        var truncatedItems = new T[actualLength];
        Array.Copy(actualItems, truncatedItems, actualLength);

        Assert.Equal(expectedItems, truncatedItems);
    }
}