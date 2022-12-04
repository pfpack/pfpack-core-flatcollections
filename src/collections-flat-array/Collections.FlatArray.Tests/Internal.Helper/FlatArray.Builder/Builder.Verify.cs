using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Builder actual, T[]? expectedItems, int expectedLength)
    {
        var type = typeof(FlatArray<T>.Builder);

        var actualItems = type.CreateGetter<BuilderFieldGetter<T, T[]?>>("items").Invoke(actual);
        Assert.Equal(expectedItems, actualItems);

        var actualLength = type.CreateGetter<BuilderFieldGetter<T, int>>("length").Invoke(actual);
        Assert.StrictEqual(expectedLength, actualLength);
    }

    internal static void VerifyInnerLength<T>(this FlatArray<T>.Builder actual, int? expectedItemsLength, int expectedLength)
    {
        var type = typeof(FlatArray<T>.Builder);

        var actualItems = type.CreateGetter<BuilderFieldGetter<T, T[]?>>("items").Invoke(actual);
        Assert.StrictEqual(expectedItemsLength, actualItems?.Length);

        var actualLength = type.CreateGetter<BuilderFieldGetter<T, int>>("length").Invoke(actual);
        Assert.StrictEqual(expectedLength, actualLength);
    }

    private delegate TValue BuilderFieldGetter<T, TValue>(in FlatArray<T>.Builder source);
}