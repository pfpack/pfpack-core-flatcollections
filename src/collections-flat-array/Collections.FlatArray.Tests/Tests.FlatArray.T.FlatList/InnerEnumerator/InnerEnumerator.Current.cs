using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(0, 1, SomeString)]
    [InlineData(1, 2, LowerSomeString, AnotherString, SomeString)]
    [InlineData(3, 5, "One", "Two", null, "Four", "Five")]
    public void InnerEnumerator_Current_IndexIsInRange_ExpectItemByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();
        var source = sourceItems.InitializeFlatListEnumerator(sourceLength, index);

        var actual = source.Current;
        var expected = coppied[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, PlusFifteen, MinusFifteen)]
    [InlineData(3, 2, null, MinusFifteen, Zero)]
    [InlineData(-1, 3, MinusOne, One, PlusFifteen)]
    public void InnerEnumerator_Current_IndexIsNotInRange_ExpectInvalidOperationException(
        int index, int sourceLength, params int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatListEnumerator(sourceLength, index);
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.Current;
    }
}