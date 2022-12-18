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

        Assert.Contains("0", actual, StringComparison.InvariantCulture);
        Assert.Contains("RecordType", actual, StringComparison.InvariantCulture);
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

        Assert.Contains(length.ToString(), actual, StringComparison.InvariantCulture);
        Assert.Contains("String", actual, StringComparison.InvariantCulture);
    }
}