using System.Collections.Generic;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayStaticTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(MinusFifteen)]
    public void FromOneItem_ExpectInnerStateIsSourceItem(int? item)
    {
        var actual = FlatArray.From(item);

        const int expectedLength = 1;
        var expectedItems = new[] { item };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromTwoItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(MinusFifteenIdRefType, null);

        const int expectedLength = 2;
        var expectedItems = new[] { MinusFifteenIdRefType, null };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromThreeItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(SomeTextRecordStruct, default, AnotherTextRecordStruct);

        const int expectedLength = 3;
        var expectedItems = new[] { SomeTextRecordStruct, default, AnotherTextRecordStruct };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromFourItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(TabString, null, AnotherString, SomeString);

        const int expectedLength = 4;
        var expectedItems = new[] { TabString, null, AnotherString, SomeString };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromFiveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<byte>(151, 21, byte.MaxValue, 211, 55);

        const int expectedLength = 5;
        var expectedItems = new byte[] { 151, 21, byte.MaxValue, 211, 55 };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromSixItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<decimal?>(decimal.MinusOne, 251.7m, null, -252, 97.86m, 751);

        const int expectedLength = 6;
        var expectedItems = new decimal?[] { decimal.MinusOne, 251.7m, null, -252, 97.86m, 751 };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromSevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From("One", "Two", "Three", "Four", "Five", null, "Seven");

        const int expectedLength = 7;
        var expectedItems = new[] { "One", "Two", "Three", "Four", "Five", null, "Seven" };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromEightItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<object?>(PlusFifteen, null, SomeString, decimal.MinusOne, byte.MaxValue, false, int.MinValue, AnotherString);

        const int expectedLength = 8;
        var expectedItems = new object?[] { PlusFifteen, null, SomeString, decimal.MinusOne, byte.MaxValue, false, int.MinValue, AnotherString };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromNineItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<long?>(long.MinValue, -891, -3781, 0, 24681, -90, -1, null, 681);

        const int expectedLength = 9;
        var expectedItems = new long?[] { long.MinValue, -891, -3781, 0, 24681, -90, -1, null, 681 };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromTenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, default, 27, -32, -955);

        const int expectedLength = 10;
        var expectedItems = new[] { MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, default, 27, -32, -955 };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromElevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<decimal?>(
            decimal.MinusOne, 8691.719m, 1361, null, 75, 682, 827, 954, decimal.MaxValue, 13289, 88);

        const int expectedLength = 11;

        var expectedItems = new decimal?[]
        {
            decimal.MinusOne, 8691.719m, 1361, null, 75, 682, 827, 954, decimal.MaxValue, 13289, 88
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromTwelveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<long?>(
            -75, 2155, 790, 825, 351, 541, 975601, long.MaxValue, 7891, null, 571, 622);

        const int expectedLength = 12;

        var expectedItems = new long?[]
        {
            -75, 2155, 790, 825, 351, 541, 975601, long.MaxValue, 7891, null, 571, 622
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromThirteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue, -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75);

        const int expectedLength = 13;

        var expectedItems = new[]
        {
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue, -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromFourteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From<byte?>(
            0, 2, 6, 3, 91, byte.MaxValue, 71, 5, 71, 52, null, 211, 86, 23);

        const int expectedLength = 14;

        var expectedItems = new byte?[]
        {
            0, 2, 6, 3, 91, byte.MaxValue, 71, 5, 71, 52, null, 211, 86, 23
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromFifteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", "Ten", "Nine",
            "Eight", null, "Six", "Five", "Four", "Three", "Two", "One");

        const int expectedLength = 15;

        var expectedItems = new[]
        {
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", "Ten", "Nine",
            "Eight", null, "Six", "Five", "Four", "Three", "Two", "One"
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromSixteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray.From(
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m);

        const int expectedLength = 16;

        var expectedItems = new[]
        {
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m
        };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }
}