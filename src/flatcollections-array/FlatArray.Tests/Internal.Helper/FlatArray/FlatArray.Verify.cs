using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState_Default<T>(this FlatArray<T> actual)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(default, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Null(actualItems);
    }

    internal static void VerifyInnerState<T>(this FlatArray<T> actual, T[]? expectedItems, int expectedLength)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);
    }

    internal static void VerifyInnerState_TheSameAssert<T>(this FlatArray<T> actual, T[]? expectedItems, int expectedLength)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Same(expectedItems, actualItems);
    }

    internal static void VerifyTruncatedState<T>(this FlatArray<T> actual, params T[]? expectedItems)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedItems?.Length ?? default, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        if (actualItems is null)
        {
            Assert.Null(expectedItems);
            return;
        }

        var truncatedItems = new T[actualLength];
        Array.Copy(actualItems, truncatedItems, actualLength);

        Assert.Equal(expectedItems, truncatedItems);
    }

    internal static void VerifyTruncatedState<T>(this FlatArray<FlatArray<T>> actual, params T[][]? expectedItems)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedItems?.Length ?? default, actualLength);

        var actualItems = actual.GetFieldValue<FlatArray<T>[]?>("items");
        if (actualItems is null)
        {
            Assert.Null(expectedItems);
            return;
        }

        Assert.NotNull(expectedItems);

        for (var i = 0; i < actualLength; i++)
        {
            actualItems[i].VerifyTruncatedState(expectedItems[i]);
        }
    }
}