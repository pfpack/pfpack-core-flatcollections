using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void IsNotEmpty_SourceIsDefault_ExpectTrue()
    {
        var source = default(FlatArray<RecordStruct?>.Builder);
        var actual = source.IsNotEmpty;

        Assert.False(actual);
    }

    [Theory]
    [InlineData(One)]
    [InlineData(MinusFifteen, null, PlusFifteen)]
    public void IsNotEmpty_SourceIsNotDefault_ExpectFalse(
        params int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder();
        var actual = source.IsNotEmpty;

        Assert.True(actual);
    }
}