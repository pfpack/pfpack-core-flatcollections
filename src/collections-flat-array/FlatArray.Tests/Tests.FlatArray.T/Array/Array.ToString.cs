using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

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
    public void ToString_InnerLengthIsLessThanInnerItemsLength_ExpectStringContainsLengthAndTypeName()
    {
        var innerItems = new[]
        {
            MinusFifteen, PlusFifteen, Zero, int.MaxValue, One
        };

        const int innerLength = 4;

        var source = innerItems.InitializeFlatArray(innerLength);
        var actual = source.ToString();

        Assert.Contains(innerLength.ToString(), actual, StringComparison.InvariantCulture);
        Assert.Contains("Int32", actual, StringComparison.InvariantCulture);
    }
}