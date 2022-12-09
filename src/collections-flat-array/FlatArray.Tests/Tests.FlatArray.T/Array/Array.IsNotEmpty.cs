using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

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
    [InlineData(SomeString)]
    [InlineData(null, EmptyString, UpperSomeString, SomeString, WhiteSpaceString)]
    public void IsNotEmpty_SourceIsNotDefault_ExpectFalse(
        params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();
        var actual = source.IsNotEmpty;

        Assert.True(actual);
    }
}