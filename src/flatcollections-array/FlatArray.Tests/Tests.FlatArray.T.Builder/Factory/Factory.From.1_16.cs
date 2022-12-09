using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(MinusFifteen)]
    public void FromOneItem_ExpectInnerStateIsSourceItem(int? item)
    {
        var actual = FlatArray<int?>.Builder.From(item);

        const int expectedLength = 1;
        var expectedItems = new[] { item };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromTwoItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<RefType?>.Builder.From(ZeroIdRefType, null);

        const int expectedLength = 2;
        var expectedItems = new[] { ZeroIdRefType, null };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromThreeItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<StructType>.Builder.From(SomeTextStructType, default, LowerSomeTextStructType);

        const int expectedLength = 3;
        var expectedItems = new[] { SomeTextStructType, default, LowerSomeTextStructType };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromFourItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<string?>.Builder.From(SomeString, null, AnotherString, EmptyString);

        const int expectedLength = 4;
        var expectedItems = new[] { SomeString, null, AnotherString, EmptyString };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromFiveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<DateOnly>.Builder.From(
            new(2021, 11, 05), new(2022, 07, 15), new(2019, 02, 14), new(1997, 12, 01), new(2015, 03, 01));

        const int expectedLength = 5;

        var expectedItems = new DateOnly[]
        {
            new(2021, 11, 05), new(2022, 07, 15), new(2019, 02, 14), new(1997, 12, 01), new(2015, 03, 01)
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromSixItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<long>.Builder.From(
            -89, -35, 57, 0, 789, 56341);

        const int expectedLength = 6;

        var expectedItems = new long[]
        {
            -89, -35, 57, 0, 789, 56341
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromSevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<object?>.Builder.From(
            null, SomeString, MinusFifteenIdRefType, MinusFifteen, false, LowerSomeTextStructType, byte.MaxValue);

        const int expectedLength = 7;

        var expectedItems = new object?[]
        {
            null, SomeString, MinusFifteenIdRefType, MinusFifteen, false, LowerSomeTextStructType, byte.MaxValue
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromEightItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<decimal?>.Builder.From(
            -751.81m, decimal.MinusOne, null, 178, -7531, -69, 275, 935);

        const int expectedLength = 8;

        var expectedItems = new decimal?[]
        {
            -751.81m, decimal.MinusOne, null, 178, -7531, -69, 275, 935
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromNineItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<long?>.Builder.From(
            264, -891, long.MaxValue, 0, 24681, -90, -1, 755, 681);

        const int expectedLength = 9;

        var expectedItems = new long?[]
        {
            264, -891, long.MaxValue, 0, 24681, -90, -1, 755, 681
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromTenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<int?>.Builder.From(
            MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, 17892, null, -32, -955);

        const int expectedLength = 10;

        var expectedItems = new int?[]
        {
            MinusFifteen, 861, Zero, int.MaxValue, 168, -90123, 17892, null, -32, -955
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromElevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<decimal>.Builder.From(
            decimal.MinusOne, 8691.719m, 1361, -789018, 75, 682,
            827, 954, decimal.MaxValue, 13289, 88);

        const int expectedLength = 11;

        var expectedItems = new[]
        {
            decimal.MinusOne, 8691.719m, 1361, -789018, 75, 682,
            827, 954, decimal.MaxValue, 13289, 88
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromTwelveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<long?>.Builder.From(
            -75, 2155, 790, 825, 351, 541,
            975601, long.MaxValue, 7891, null, 571, 622);

        const int expectedLength = 12;

        var expectedItems = new long?[]
        {
            -75, 2155, 790, 825, 351, 541,
            975601, long.MaxValue, 7891, null, 571, 622
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromThirteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<double>.Builder.From(
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue,
            -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75);

        const int expectedLength = 13;

        var expectedItems = new[]
        {
            98, -276.54, 681, double.Epsilon, -89.7801, 9950, double.MaxValue,
            -5.985, double.PositiveInfinity, 98.71, -9701, 72, 75
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromFourteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<byte>.Builder.From(
            0, 2, 6, 3, 91, byte.MaxValue, 71,
            5, 71, 52, 122, 211, 86, 23);

        const int expectedLength = 14;

        var expectedItems = new byte[]
        {
            0, 2, 6, 3, 91, byte.MaxValue, 71,
            5, 71, 52, 122, 211, 86, 23
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromFifteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<string?>.Builder.From(
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", string.Empty, "Nine",
            "Eight", "Seven", "Six", "Five", "Four", "Three", "Two", "One");

        const int expectedLength = 15;

        var expectedItems = new[]
        {
            "Fifteen", "Fourteen", "Thirteen", "Twelve", "Eleven", string.Empty, "Nine",
            "Eight", "Seven", "Six", "Five", "Four", "Three", "Two", "One"
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromSixteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = FlatArray<decimal>.Builder.From(
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m);

        const int expectedLength = 16;

        var expectedItems = new[]
        {
            decimal.MinusOne, 178.81m, 24, -75195.71m, decimal.Zero, 75, 168, -300.9m,
            9005, decimal.MaxValue, 198234.71m, decimal.One, decimal.MinValue, 7, -191, -275000.01m
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }
}