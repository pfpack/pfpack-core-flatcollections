using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ConstructFromArray_SourceArrayIsNull_ExpectInnerLengthIsZero()
    {
        int[]? sourceArray = null;
        var source = new FlatArray<int>(sourceArray);

        var actual = source.GetInnerLength();
        const int expected = 0;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromArray_SourceArrayIsNull_ExpectInnerItemsIsNull()
    {
        string[]? sourceArray = null;
        var source = new FlatArray<string>(sourceArray);

        var actual = source.GetInnerItems();
        Assert.Null(actual);
    }

    [Fact]
    public void ConstructFromArray_SourceArrayIsEmpty_ExpectInnerLengthIsZero()
    {
        var sourceArray = Array.Empty<RefType>();
        var source = new FlatArray<RefType>(sourceArray);

        var actual = source.GetInnerLength();
        const int expected = 0;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromArray_SourceArrayIsEmpty_ExpectInnerItemsIsNull()
    {
        var sourceArray = Array.Empty<RecordType?>();
        var source = new FlatArray<RecordType?>(sourceArray);

        var actual = source.GetInnerItems();
        Assert.Null(actual);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(null, LowerAnotherString, EmptyString, WhiteSpaceString, UpperSomeString)]
    [InlineData("01", "02", "03", null, "05", "06", "07", "08", "09", "10", EmptyString, "12", "13", "14", "15", "16", "17")]
    public void ConstructFromArray_SourceArrayIsNotEmpty_ExpectInnerLengthIsEqualToSourceArrayLength(
        params string?[] sourceArray)
    {
        var source = new FlatArray<string?>(sourceArray);

        var actual = source.GetInnerLength();
        var expected = sourceArray.Length;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, MinusOne, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, 21, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void ConstructFromArray_SourceArrayIsNotEmpty_ExpectInnerItemsAreEqualToSourceArrayItems(
        params int[] sourceArray)
    {
        var source = new FlatArray<int>(sourceArray);
        var actual = source.GetInnerItems();

        Assert.NotSame(sourceArray, actual);
        Assert.Equal(sourceArray, actual);
    }
}