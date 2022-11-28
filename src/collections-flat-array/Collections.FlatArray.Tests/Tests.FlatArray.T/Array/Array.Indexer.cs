using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(MinusFifteen)]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    public void Indexer_SourceIsDefault_ExpectArgumentOutOfRangeException(int index)
    {
        var source = default(FlatArray<RefType>);
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);

        Assert.Equal("index", ex.ParamName);

        void Test()
            =>
            _ = source[index];
    }

    [Theory]
    [InlineData(0, EmptyString)]
    [InlineData(2, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(3, null, "One", "Two", "Three")]
    public void Indexer_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();

        var actual = source[index];
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(5, EmptyString, SomeString)]
    [InlineData(-1, LowerSomeString, null, SomeString)]
    public void Indexer_IndexIsOutOfRange_ExpectArgumentOutOfRangeException(
        int index, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);

        Assert.Equal("index", ex.ParamName);

        void Test()
            =>
            _ = source[index];
    }
}