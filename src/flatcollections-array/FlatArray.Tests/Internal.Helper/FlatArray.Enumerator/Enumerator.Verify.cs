using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Enumerator actual, T[] expectedItems, int expectedIndex)
    {
        var type = typeof(FlatArray<T>.Enumerator);

        var actualItems = type.CreateGetter<EnumeratorItemsGetter<T>>("items").Invoke(actual);
        Assert.Equal(expectedItems, actualItems.ToArray());

        var actualIndex = type.CreateGetter<EnumeratorIndexGetter<T>>("index").Invoke(actual);
        Assert.StrictEqual(expectedIndex, actualIndex);
    }

    private delegate ReadOnlySpan<T> EnumeratorItemsGetter<T>(in FlatArray<T>.Enumerator source);

    private delegate int EnumeratorIndexGetter<T>(in FlatArray<T>.Enumerator source);
}