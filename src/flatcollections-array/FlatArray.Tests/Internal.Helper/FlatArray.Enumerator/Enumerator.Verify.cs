using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Enumerator actual, int expectedLength, T[]? expectedItems, int expectedIndex)
    {
        var type = typeof(FlatArray<T>.Enumerator);

        var actualLength = type.CreateGetter<EnumeratorLengthGetter<T>>("length").Invoke(actual);
        Assert.Equal(expectedLength, actualLength);

        var actualItems = type.CreateGetter<EnumeratorItemsGetter<T>>("items").Invoke(actual);
        Assert.Equal(expectedItems, actualItems);

        var actualIndex = type.CreateGetter<EnumeratorIndexGetter<T>>("index").Invoke(actual);
        Assert.StrictEqual(expectedIndex, actualIndex);
    }

    private delegate int EnumeratorLengthGetter<T>(in FlatArray<T>.Enumerator source);

    private delegate T[] EnumeratorItemsGetter<T>(in FlatArray<T>.Enumerator source);

    private delegate int EnumeratorIndexGetter<T>(in FlatArray<T>.Enumerator source);
}