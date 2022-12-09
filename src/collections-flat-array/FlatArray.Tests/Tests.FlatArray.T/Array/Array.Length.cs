using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void GetLength_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RefType>);

        var actual = source.Length;
        const int expected = default;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, Zero)]
    [InlineData(3, PlusFifteen, null, MinusOne)]
    [InlineData(2, PlusFifteen, null, MinusOne)]
    public void GetLength_SourceIsNotDefault_ExpectInnerLength(
        int innerLength, params int?[] innerItems)
    {
        var source = innerItems.InitializeFlatArray(innerLength);

        var actual = source.Length;
        var expected = innerLength;

        Assert.Equal(expected, actual);
    }
}