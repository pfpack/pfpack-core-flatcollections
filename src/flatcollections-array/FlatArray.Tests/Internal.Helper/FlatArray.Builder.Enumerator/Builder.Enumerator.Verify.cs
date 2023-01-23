using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(
        this FlatArray<T>.Builder.Enumerator actual, int expectedBuilderLength, T[] expectedBuilderItems, int expectedIndex)
    {
        var actualBuilder = actual.GetFieldValue<FlatArray<T>.Builder>("builder");
        Assert.NotNull(actualBuilder);
        actualBuilder.VerifyInnerState(expectedBuilderItems, expectedBuilderLength);

        var actualIndex = actual.GetStructFieldValue<int>("index");
        Assert.StrictEqual(expectedIndex, actualIndex);
    }
}