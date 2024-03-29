using System;
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

        const string expected = "FlatArray<StructType>[0]";
        Assert.Equal(expected, actual);
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

        const string expected = "FlatArray<Int32>[4]";
        Assert.Equal(expected, actual);
    }
}