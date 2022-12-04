using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Builder actual, T[]? expectedItems, int expectedLength)
    {
        var actualItems = GetFlatArrayBuilderItemsGetter<T, T[]?>("items").Invoke(actual);
        Assert.Equal(expectedItems, actualItems);

        var actualLength = GetFlatArrayBuilderItemsGetter<T, int>("length").Invoke(actual);
        Assert.StrictEqual(expectedLength, actualLength);
    }

    internal static void VerifyInnerLength<T>(this FlatArray<T>.Builder actual, int? expectedItemsLength, int expectedLength)
    {
        var actualItems = GetFlatArrayBuilderItemsGetter<T, T[]?>("items").Invoke(actual);
        Assert.StrictEqual(expectedItemsLength, actualItems?.Length);

        var actualLength = GetFlatArrayBuilderItemsGetter<T, int>("length").Invoke(actual);
        Assert.StrictEqual(expectedLength, actualLength);
    }

    private delegate TValue FlatArrayBuilderFieldGetter<T, TValue>(in FlatArray<T>.Builder source);

    private static FlatArrayBuilderFieldGetter<T, TValue> GetFlatArrayBuilderItemsGetter<T, TValue>(string fieldName)
    {
        var type = typeof(FlatArray<T>.Builder);
        var method = type.CreateGetter(fieldName);

        var getter = method.CreateDelegate(typeof(FlatArrayBuilderFieldGetter<,>).MakeGenericType(typeof(T), typeof(TValue)));
        return (FlatArrayBuilderFieldGetter<T, TValue>)getter;
    }
}