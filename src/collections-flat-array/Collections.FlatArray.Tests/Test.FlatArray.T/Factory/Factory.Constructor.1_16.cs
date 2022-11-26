using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(SomeString)]
    public void ConstructFromOneItem_ExpectInnerLengthIsOne(string? item)
    {
        var source = new FlatArray<string?>(item);

        var actual = source.GetInnerLength();
        const int expected = 1;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(PlusFifteen)]
    public void ConstructFromOneItem_ExpectInnerItemsAreSourceItem(int? item)
    {
        var source = new FlatArray<int?>(item);

        var actual = source.GetInnerItems();
        var expected = new[] { item };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTwoItems_ExpectInnerLengthIsTwo()
    {
        var source = new FlatArray<RefType?>(null, MinusFifteenIdRefType);

        var actual = source.GetInnerLength();
        const int expected = 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTwoItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, null);

        var actual = source.GetInnerItems();
        var expected = new[] { PlusFifteenIdLowerSomeStringNameRecord, null };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromThreeItems_ExpectInnerLengthIsThree()
    {
        var source = new FlatArray<RecordStruct?>(SomeTextRecordStruct, null, AnotherTextRecordStruct);

        var actual = source.GetInnerLength();
        const int expected = 3;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromThreeItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string>(SomeString, AnotherString, string.Empty);

        var actual = source.GetInnerItems();
        var expected = new[] { SomeString, AnotherString, string.Empty };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFourItems_ExpectInnerLengthIsFour()
    {
        var source = new FlatArray<int>(PlusFifteen, MinusOne, Zero, int.MaxValue);

        var actual = source.GetInnerLength();
        const int expected = 4;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFourItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<RefType?>(null, PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType);

        var actual = source.GetInnerItems();
        var expected = new[] { null, PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFiveItems_ExpectInnerLengthIsFive()
    {
        var source = new FlatArray<DateOnly>(
            new(2021, 11, 05), new(2022, 07, 15), new(2019, 02, 14), new(1997, 12, 01), new(2015, 03, 01));

        var actual = source.GetInnerLength();
        const int expected = 5;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFiveItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<int>(
            51, 2801, -71, int.MaxValue, 67);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            51, 2801, -71, int.MaxValue, 67
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSixItems_ExpectInnerLengthIsSix()
    {
        var source = new FlatArray<long>(
            -89, -35, 57, 0, 789, 56341);

        var actual = source.GetInnerLength();
        const int expected = 6;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSixItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string?>(
            "1:One", "2:Two", "3:Three", "4:Four", "5:Five", null);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "1:One", "2:Two", "3:Three", "4:Four", "5:Five", null
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSevenItems_ExpectInnerLengthIsSeven()
    {
        var source = new FlatArray<object>(
            PlusFifteen, SomeString, MinusFifteenIdRefType, decimal.One, false, LowerSomeTextStructType, byte.MaxValue);

        var actual = source.GetInnerLength();
        const int expected = 7;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSevenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<double?>(
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon);

        var actual = source.GetInnerItems();

        var expected = new double?[]
        {
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromEightItems_ExpectInnerLengthIsEight()
    {
        var source = new FlatArray<decimal?>(
            -751.81m, decimal.MinusOne, null, 178, -7531, -69, 275, 935);

        var actual = source.GetInnerLength();
        const int expected = 8;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromEightItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<uint>(
            189165, 41, 6, 0, 891, 2546, 64, 147);

        var actual = source.GetInnerItems();

        var expected = new uint[]
        {
            189165, 41, 6, 0, 891, 2546, 64, 147
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromNineItems_ExpectInnerLengthIsNine()
    {
        var source = new FlatArray<long?>(
            264, -891, long.MaxValue, 0, 24681, -90, -1, 755, 681);

        var actual = source.GetInnerLength();
        const int expected = 9;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromNineItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string?>(
            SomeString, LowerAnotherString, null, EmptyString, AnotherString,
            UpperSomeString, WhiteSpaceString, UpperAnotherString, TabString);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            SomeString, LowerAnotherString, null, EmptyString, AnotherString,
            UpperSomeString, WhiteSpaceString, UpperAnotherString, TabString
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTenItems_ExpectInnerLengthIsTen()
    {
        var source = new FlatArray<int?>(
            MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, 17892, null, -32, -955);

        var actual = source.GetInnerLength();
        const int expected = 10;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<byte>(
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17);

        var actual = source.GetInnerItems();

        var expected = new byte[]
        {
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromElevenItems_ExpectInnerLengthIsEleven()
    {
        var source = new FlatArray<decimal>(
            decimal.MinusOne, 8691.719m, 1361, -789018, 75, 682,
            827, 954, decimal.MaxValue, 13289, 88);

        var actual = source.GetInnerLength();
        const int expected = 11;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromElevenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string?>(
            "Eleventh", "Tenth", "Ninth", "Eighth", "Seventh", null,
            "Fifth", "Fourth", "Third", "Second", "First");

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "Eleventh", "Tenth", "Ninth", "Eighth", "Seventh", null,
            "Fifth", "Fourth", "Third", "Second", "First"
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTwelveItems_ExpectInnerLengthIsTwelve()
    {
        var source = new FlatArray<long?>(
            -75, 2155, 790, 825, 351, 541,
            975601, long.MaxValue, 7891, null, 571, 622);

        var actual = source.GetInnerLength();
        const int expected = 12;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromTwelveItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<int>(
            68, 982, 75, 30121, 5007, int.MinValue,
            871, Zero, 551, -3092, 27, -893);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            68, 982, 75, 30121, 5007, int.MinValue,
            871, Zero, 551, -3092, 27, -893
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromThirteenItems_ExpectInnerLengthIsThirteen()
    {
        var source = new FlatArray<double>(
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue,
            -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75);

        var actual = source.GetInnerLength();
        const int expected = 13;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromThirteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string?>(
            "First", "Second", "Third", "Fourth", "Fifth", "Sixth", string.Empty,
            "Seventh", "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth");

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "First", "Second", "Third", "Fourth", "Fifth", "Sixth", string.Empty,
            "Seventh", "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth"
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFourteenItems_ExpectInnerLengthIsFourteen()
    {
        var source = new FlatArray<byte>(
            0, 2, 6, 3, 91, byte.MaxValue, 71,
            5, 71, 52, 122, 211, 86, 23);

        var actual = source.GetInnerLength();
        const int expected = 14;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFourteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<long>(
            -205, long.MaxValue, 78, 9717253, 27, -125, 51,
            long.MinValue, 11, 27, 95123, Zero, 82, 61);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            -205, long.MaxValue, 78, 9717253, 27, -125, 51,
            long.MinValue, 11, 27, 95123, Zero, 82, 61
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFifteenItems_ExpectInnerLengthIsFifteen()
    {
        var source = new FlatArray<string?>(
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", string.Empty, "Nine",
            "Eight", "Seven", "Six", "Five", "Four", "Three", "Two", "One");

        var actual = source.GetInnerLength();
        const int expected = 15;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromFifteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<int>(
            71, 22, 789, int.MinValue, 157, PlusFifteen, 102937, -91,
            78612, -21, -188, Zero, int.MaxValue, PlusFifteen, 56, -101);

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            71, 22, 789, int.MinValue, 157, PlusFifteen, 102937, -91,
            78612, -21, -188, Zero, int.MaxValue, PlusFifteen, 56, -101
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSixteenItems_ExpectInnerLengthIsSixteen()
    {
        var source = new FlatArray<decimal>(
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m);

        var actual = source.GetInnerLength();
        const int expected = 16;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConstructFromSixteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = new FlatArray<string?>(
            "One", "Two", "Three", "Four", "Five", null, "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", string.Empty, "Fourteen", "Fifteen", "Sixteen");

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "One", "Two", "Three", "Four", "Five", null, "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", string.Empty, "Fourteen", "Fifteen", "Sixteen"
        };

        Assert.Equal(expected, actual);
    }
}