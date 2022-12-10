using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void IndexerGet_SourceIsEmpty_ExpectIndexOutOfRangeException(int index)
    {
        var source = TestHelper.CreateEmptyFlatList<RecordType>();
        _ = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source[index];
    }

    [Theory]
    [InlineData(0, 1, MinusFifteen)]
    [InlineData(1, 2, null, PlusFifteen, One)]
    [InlineData(2, 3, Zero, MinusOne, null, PlusFifteen)]
    [InlineData(3, 4, PlusFifteen, null, One, MinusFifteen)]
    public void IndexerGet_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);

        var actual = source[index];
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, EmptyString)]
    [InlineData(1, 1, SomeString, TabString)]
    [InlineData(5, 2, null, UpperAnotherString)]
    [InlineData(-1, 3, TabString, LowerSomeString, AnotherString)]
    public void IndexerGet_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source[index];
    }
}