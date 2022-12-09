using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(
        this FlatArray<T>.Builder.Enumerator actual, T[]? expectedBuilderItems, int expectedBuilderLength, int expectedIndex)
    {
        var type = typeof(FlatArray<T>.Builder.Enumerator);

        var actualBuilder = type.CreateGetter<BuilderEnumeratorBuilderGetter<T>>("builder").Invoke(actual);
        actualBuilder.VerifyInnerState(expectedBuilderItems, expectedBuilderLength);

        var actualIndex = type.CreateGetter<BuilderEnumeratorIndexGetter<T>>("index").Invoke(actual);
        Assert.StrictEqual(expectedIndex, actualIndex);
    }

    private delegate FlatArray<T>.Builder BuilderEnumeratorBuilderGetter<T>(in FlatArray<T>.Builder.Enumerator source);

    private delegate int BuilderEnumeratorIndexGetter<T>(in FlatArray<T>.Builder.Enumerator source);
}