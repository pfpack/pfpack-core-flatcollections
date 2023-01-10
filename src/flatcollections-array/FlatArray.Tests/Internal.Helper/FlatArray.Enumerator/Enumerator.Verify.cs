using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Enumerator actual, int expectedLength, T[]? expectedItems, int expectedIndex)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Equal(expectedItems, actualItems);

        var actualIndex = actual.GetStructFieldValue<int>("index");
        Assert.StrictEqual(expectedIndex, actualIndex);
    }
}