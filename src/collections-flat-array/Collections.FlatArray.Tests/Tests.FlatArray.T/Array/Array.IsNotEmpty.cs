using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void IsNotEmpty_SourceIsDefault_ExpectFalse()
    {
        var source = default(FlatArray<RefType>);
        var actual = source.IsNotEmpty;

        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false, true, null)]
    public void IsNotEmpty_SourceIsNotDefault_ExpectFalse(params bool?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();
        var actual = source.IsNotEmpty;

        Assert.True(actual);
    }
}