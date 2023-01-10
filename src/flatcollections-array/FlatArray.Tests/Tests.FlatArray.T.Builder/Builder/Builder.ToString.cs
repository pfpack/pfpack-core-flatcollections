using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void ToString_SourceIsDefault_ExpectStringContainsZeroAndTypeName()
    {
        var source = new FlatArray<RecordType>.Builder();
        var actual = source.ToString();

        const string expected = "FlatArray<RecordType>.Builder[0]";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToString_SourceIsNotDefault_ExpectStringContainsLengthAndTypeName()
    {
        var sourceItems = new[]
        {
            SomeString, EmptyString, null, WhiteSpaceString, AnotherString
        };

        const int length = 3;

        var source = sourceItems.InitializeFlatArrayBuilder(length);
        var actual = source.ToString();

        const string expected = "FlatArray<String>.Builder[3]";
        Assert.Equal(expected, actual);
    }
}