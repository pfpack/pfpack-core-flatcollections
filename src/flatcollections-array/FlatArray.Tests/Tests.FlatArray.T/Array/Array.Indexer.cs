using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(MinusFifteen)]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    [InlineData(PlusFifteen)]
    public void Indexer_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var source = default(FlatArray<RefType>);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source[index];
    }

    [Theory]
    [InlineData(0, 1, EmptyString)]
    [InlineData(0, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(0, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(1, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(2, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(0, 4, null, "One", "Two", "Three")]
    [InlineData(1, 4, null, "One", "Two", "Three")]
    [InlineData(2, 4, null, "One", "Two", "Three")]
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
    public void Indexer_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArray(sourceLength);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source[index];
    }
}