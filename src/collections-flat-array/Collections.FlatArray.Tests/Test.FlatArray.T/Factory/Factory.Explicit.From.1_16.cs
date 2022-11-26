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
    [InlineData(true)]
    public void FromOneItem_ExpectInnerLengthIsOne(bool? item)
    {
        var source = FlatArray<bool?>.From(item);

        var actual = source.GetInnerLength();
        const int expected = 1;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(SomeString)]
    public void FromOneItem_ExpectInnerItemsAreSourceItem(string? item)
    {
        var source = FlatArray<string?>.From(item);

        var actual = source.GetInnerItems();
        var expected = new[] { item };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromTwoItems_ExpectInnerLengthIsTwo()
    {
        var source = FlatArray<StructType>.From(SomeTextStructType, LowerSomeTextStructType);

        var actual = source.GetInnerLength();
        const int expected = 2;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromTwoItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<RefType>.From(MinusFifteenIdRefType, ZeroIdRefType);

        var actual = source.GetInnerItems();
        var expected = new[] { MinusFifteenIdRefType, ZeroIdRefType };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromThreeItems_ExpectInnerLengthIsThree()
    {
        var source = FlatArray<RecordType?>.From(null, MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord);

        var actual = source.GetInnerLength();
        const int expected = 3;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromThreeItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<RecordStruct>.From(SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct);

        var actual = source.GetInnerItems();
        var expected = new[] { SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFourItems_ExpectInnerLengthIsFour()
    {
        var source = FlatArray<string?>.From(string.Empty, SomeString, AnotherString, EmptyString);

        var actual = source.GetInnerLength();
        const int expected = 4;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFourItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<int?>.From(Zero, MinusFifteen, One, null);

        var actual = source.GetInnerItems();
        var expected = new int?[] { Zero, MinusFifteen, One, null };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFiveItems_ExpectInnerLengthIsFive()
    {
        var source = FlatArray<DateOnly>.From(
            new(2021, 11, 05), new(2022, 07, 15), new(2019, 02, 14), new(1997, 12, 01), new(2015, 03, 01));

        var actual = source.GetInnerLength();
        const int expected = 5;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFiveItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<int?>.From(
            51, 2801, null, int.MaxValue, 67);

        var actual = source.GetInnerItems();

        var expected = new int?[]
        {
            51, 2801, null, int.MaxValue, 67
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromSixItems_ExpectInnerLengthIsSix()
    {
        var source = FlatArray<long>.From(
            -89, -35, 57, 0, 789, 56341);

        var actual = source.GetInnerLength();
        const int expected = 6;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromSixItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<string>.From(
            "1:One", "2:Two", "3:Three", "4:Four", "5:Five", "6:Six");

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "1:One", "2:Two", "3:Three", "4:Four", "5:Five", "6:Six"
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromSevenItems_ExpectInnerLengthIsSeven()
    {
        var source = FlatArray<object?>.From(
            null, SomeString, MinusFifteenIdRefType, MinusFifteen, false, LowerSomeTextStructType, byte.MaxValue);

        var actual = source.GetInnerLength();
        const int expected = 7;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromSevenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<double?>.From(
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon);

        var actual = source.GetInnerItems();

        var expected = new double?[]
        {
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromEightItems_ExpectInnerLengthIsEight()
    {
        var source = FlatArray<decimal?>.From(
            -751.81m, decimal.MinusOne, null, 178, -7531, -69, 275, 935);

        var actual = source.GetInnerLength();
        const int expected = 8;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromEightItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<uint>.From(
            189165, 41, 6, 0, 891, 2546, 64, 147);

        var actual = source.GetInnerItems();

        var expected = new uint[]
        {
            189165, 41, 6, 0, 891, 2546, 64, 147
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromNineItems_ExpectInnerLengthIsNine()
    {
        var source = FlatArray<long?>.From(
            264, -891, long.MaxValue, 0, 24681, -90, -1, 755, 681);

        var actual = source.GetInnerLength();
        const int expected = 9;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromNineItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<string?>.From(
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
    public void FromTenItems_ExpectInnerLengthIsTen()
    {
        var source = FlatArray<int?>.From(
            MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, 17892, null, -32, -955);

        var actual = source.GetInnerLength();
        const int expected = 10;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromTenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<byte>.From(
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17);

        var actual = source.GetInnerItems();

        var expected = new byte[]
        {
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromElevenItems_ExpectInnerLengthIsEleven()
    {
        var source = FlatArray<decimal>.From(
            decimal.MinusOne, 8691.719m, 1361, -789018, 75, 682,
            827, 954, decimal.MaxValue, 13289, 88);

        var actual = source.GetInnerLength();
        const int expected = 11;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromElevenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<string?>.From(
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
    public void FromTwelveItems_ExpectInnerLengthIsTwelve()
    {
        var source = FlatArray<long?>.From(
            -75, 2155, 790, 825, 351, 541,
            975601, long.MaxValue, 7891, null, 571, 622);

        var actual = source.GetInnerLength();
        const int expected = 12;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromTwelveItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<int>.From(
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
    public void FromThirteenItems_ExpectInnerLengthIsThirteen()
    {
        var source = FlatArray<double>.From(
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue,
            -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75);

        var actual = source.GetInnerLength();
        const int expected = 13;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromThirteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<string?>.From(
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
    public void FromFourteenItems_ExpectInnerLengthIsFourteen()
    {
        var source = FlatArray<byte>.From(
            0, 2, 6, 3, 91, byte.MaxValue, 71,
            5, 71, 52, 122, 211, 86, 23);

        var actual = source.GetInnerLength();
        const int expected = 14;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFourteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<long>.From(
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
    public void FromFifteenItems_ExpectInnerLengthIsFifteen()
    {
        var source = FlatArray<string?>.From(
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", string.Empty, "Nine",
            "Eight", "Seven", "Six", "Five", "Four", "Three", "Two", "One");

        var actual = source.GetInnerLength();
        const int expected = 15;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromFifteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<int>.From(
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
    public void FromSixteenItems_ExpectInnerLengthIsSixteen()
    {
        var source = FlatArray<decimal>.From(
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m);

        var actual = source.GetInnerLength();
        const int expected = 16;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromSixteenItems_ExpectInnerItemsAreSourceItems()
    {
        var source = FlatArray<string>.From(
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen");

        var actual = source.GetInnerItems();

        var expected = new[]
        {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen"
        };

        Assert.Equal(expected, actual);
    }
}