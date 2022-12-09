using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void IsEmpty_SourceIsDefault_ExpectTrue()
    {
        var source = default(FlatArray<StructType>);
        var actual = source.IsEmpty;

        Assert.True(actual);
    }

    [Theory]
    [InlineData(EmptyString)]
    [InlineData(null, SomeString, LowerSomeString, EmptyString, AnotherString)]
    public void IsEmpty_SourceIsNotDefault_ExpectFalse(
        params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();
        var actual = source.IsEmpty;

        Assert.False(actual);
    }
}