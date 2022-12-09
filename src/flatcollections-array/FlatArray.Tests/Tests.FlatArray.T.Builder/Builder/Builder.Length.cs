using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void GetLength_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<StructType?>.Builder);

        var actual = source.Length;
        const int expected = default;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(2, AnotherString, null, SomeString, EmptyString)]
    [InlineData(3, null, EmptyString, AnotherString)]
    public void GetLength_SourceIsNotDefault_ExpectInnerLength(
        int innerLength, params string?[] innerItems)
    {
        var source = innerItems.InitializeFlatArrayBuilder(innerLength);

        var actual = source.Length;
        var expected = innerLength;

        Assert.Equal(expected, actual);
    }
}