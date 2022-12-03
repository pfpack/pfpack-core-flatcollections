using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyDefaultState<T>(this FlatArray<T> actual)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        const int expectedLength = default;

        Assert.Equal(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        Assert.Null(actualItems);
    }
}