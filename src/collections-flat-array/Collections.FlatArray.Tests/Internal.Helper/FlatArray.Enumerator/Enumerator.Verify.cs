using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Enumerator actual, T[] expectedItems, int expectedIndex)
    {
        var actualItems = GetFlatArrayEnumeratorItemsGetter<T>().Invoke(actual);
        Assert.Equal(expectedItems, actualItems.ToArray());

        var actualIndex = GetFlatArrayEnumeratorIndexGetter<T>().Invoke(actual);
        Assert.StrictEqual(expectedIndex, actualIndex);
    }

    private delegate ReadOnlySpan<T> FlatArrayEnumeratorItemsGetter<T>(in FlatArray<T>.Enumerator source);

    private delegate int FlatArrayEnumeratorIndexGetter<T>(in FlatArray<T>.Enumerator source);

    private static FlatArrayEnumeratorItemsGetter<T> GetFlatArrayEnumeratorItemsGetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var method = type.CreateGetter("items");

        var getter = method.CreateDelegate(typeof(FlatArrayEnumeratorItemsGetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayEnumeratorItemsGetter<T>)getter;
    }

    private static FlatArrayEnumeratorIndexGetter<T> GetFlatArrayEnumeratorIndexGetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var method = type.CreateGetter("index");

        var getter = method.CreateDelegate(typeof(FlatArrayEnumeratorIndexGetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayEnumeratorIndexGetter<T>)getter;
    }
}