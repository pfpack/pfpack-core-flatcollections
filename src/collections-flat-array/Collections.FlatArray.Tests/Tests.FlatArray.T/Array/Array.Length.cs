using System.Collections.Generic;
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
    [InlineData(Zero)]
    [InlineData(PlusFifteen, null, MinusOne)]
    public void GetLength_SourceIsNotDefault_ExpectInnerLength(params int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();

        var actual = source.Length;
        var expected = sourceItems.Length;

        Assert.Equal(expected, actual);
    }
}