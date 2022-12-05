using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

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
    [InlineData(0, 1, EmptyString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(3, 4, null, "One", "Two", "Three")]
    public void Indexer_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray(sourceLength);

        var actual = source[index];
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, EmptyString, AnotherString)]
    [InlineData(5, 2, EmptyString, SomeString)]
    [InlineData(-1, 3, LowerSomeString, null, SomeString)]
    public void Indexer_IndexIsOutOfRange_ExpectArgumentOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray(sourceLength);
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);

        Assert.Equal("index", ex.ParamName);

        void Test()
            =>
            _ = source[index];
    }
}