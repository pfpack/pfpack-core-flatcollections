using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(
        this FlatArray<T>.Builder.Enumerator actual, T[]? expectedBuilderItems, int expectedBuilderLength, int expectedIndex)
    {
        var actualBuilder = GetFlatArrayBuilderEnumeratorBuilderGetter<T>().Invoke(actual);
        actualBuilder.VerifyInnerState(expectedBuilderItems, expectedBuilderLength);

        var actualIndex = GetFlatArrayBuilderEnumeratorIndexGetter<T>().Invoke(actual);
        Assert.StrictEqual(expectedIndex, actualIndex);
    }

    private delegate FlatArray<T>.Builder FlatArrayBuilderEnumeratorBuilderGetter<T>(in FlatArray<T>.Builder.Enumerator source);

    private delegate int FlatArrayBuilderEnumeratorIndexGetter<T>(in FlatArray<T>.Builder.Enumerator source);

    private static FlatArrayBuilderEnumeratorBuilderGetter<T> GetFlatArrayBuilderEnumeratorBuilderGetter<T>()
    {
        var type = typeof(FlatArray<T>.Builder.Enumerator);
        var method = type.CreateGetter("builder");

        var getter = method.CreateDelegate(typeof(FlatArrayBuilderEnumeratorBuilderGetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayBuilderEnumeratorBuilderGetter<T>)getter;
    }

    private static FlatArrayBuilderEnumeratorIndexGetter<T> GetFlatArrayBuilderEnumeratorIndexGetter<T>()
    {
        var type = typeof(FlatArray<T>.Builder.Enumerator);
        var method = type.CreateGetter("index");

        var getter = method.CreateDelegate(typeof(FlatArrayBuilderEnumeratorIndexGetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayBuilderEnumeratorIndexGetter<T>)getter;
    }
}