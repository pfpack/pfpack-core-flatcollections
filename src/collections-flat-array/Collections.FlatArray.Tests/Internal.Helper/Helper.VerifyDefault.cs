using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class TestHelper
{
    internal static void VerifyDefaultState<T>(FlatArray<T> actual)
    {
        var actualLength = actual.GetInnerLength();
        const int expectedLength = default;

        Assert.Equal(expectedLength, actualLength);

        var actualItems = actual.GetInnerItems();
        Assert.Null(actualItems);
    }
}