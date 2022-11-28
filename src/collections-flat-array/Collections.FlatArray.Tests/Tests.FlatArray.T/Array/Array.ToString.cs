using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ToString_SourceIsDefault_ExpectStringContainsZeroAndTypeName()
    {
        var source = default(FlatArray<StructType>);
        var actual = source.ToString();

        Assert.Contains("0", actual, StringComparison.InvariantCulture);
        Assert.Contains("StructType", actual, StringComparison.InvariantCulture);
    }

    [Fact]
    public void ToString_SourceIsNotDefault_ExpectStringContainsLengthAndTypeName()
    {
        var sourceItems = new[]
        {
            ZeroIdRefType, PlusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray();
        var actual = source.ToString();

        Assert.Contains("2", actual, StringComparison.InvariantCulture);
        Assert.Contains("RefType", actual, StringComparison.InvariantCulture);
    }
}