using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void IsEmpty_SourceIsDefault_ExpectTrue()
    {
        var source = default(FlatArray<RecordType>.Builder);
        var actual = source.IsEmpty;

        Assert.True(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false, false, null, true)]
    public void IsEmpty_SourceIsNotDefault_ExpectFalse(
        params bool?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder();
        var actual = source.IsEmpty;

        Assert.False(actual);
    }
}