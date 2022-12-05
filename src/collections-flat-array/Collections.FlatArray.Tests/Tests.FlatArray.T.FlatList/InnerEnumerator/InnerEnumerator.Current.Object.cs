using System;
using System.Collections;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(0, 1, PlusFifteen)]
    [InlineData(1, 3, null, Zero, One)]
    [InlineData(4, 5, MinusFifteen, MinusOne, One, Zero, PlusFifteen)]
    public void InnerEnumerator_CurrentObject_IndexIsInRange_ExpectItemByIndex(
        int index, int sourceLength, params int?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();
        var source = (IEnumerator)sourceItems.InitializeFlatListEnumerator(sourceLength, index);

        var actual = source.Current;
        var expected = coppied[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-1, 0)]
    [InlineData(1, 1, EmptyString)]
    [InlineData(3, 2, SomeString, null, EmptyString, WhiteSpaceString)]
    [InlineData(-1, 3, UpperSomeString, SomeString, TabString)]
    public void InnerEnumerator_CurrentObject_IndexIsNotInRange_ExpectInvalidOperationException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = (IEnumerator)sourceItems.InitializeFlatListEnumerator(sourceLength, index);
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.Current;
    }
}