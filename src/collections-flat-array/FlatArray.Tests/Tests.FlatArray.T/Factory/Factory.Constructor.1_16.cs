using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(PlusFifteen)]
    public void ConstructFromOneItem_ExpectInnerStateIsSourceItem(int? item)
    {
        var actual = new FlatArray<int?>(item);

        const int expectedLength = 1;
        var expectedItems = new[] { item };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromTwoItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, null);

        const int expectedLength = 2;
        var expectedItems = new[] { PlusFifteenIdLowerSomeStringNameRecord, null };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromThreeItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string>(SomeString, AnotherString, string.Empty);

        const int expectedLength = 3;
        var expectedItems = new[] { SomeString, AnotherString, string.Empty };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromFourItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<RefType?>(null, PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType);

        const int expectedLength = 4;
        var expectedItems = new[] { null, PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromFiveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<int>(51, 2801, -71, int.MaxValue, 67);

        const int expectedLength = 5;
        var expectedItems = new[] { 51, 2801, -71, int.MaxValue, 67 };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromSixItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string?>("1:One", "2:Two", "3:Three", "4:Four", "5:Five", null);

        const int expectedLength = 6;
        var expectedItems = new[] { "1:One", "2:Two", "3:Three", "4:Four", "5:Five", null };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromSevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<double?>(
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon);

        const int expectedLength = 7;

        var expectedItems = new double?[]
        {
            null, 1478, -791, double.PositiveInfinity, 78.891, 9, double.Epsilon
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromEightItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<uint>(
            189165, 41, 6, 0, 891, 2546, 64, 147);

        const int expectedLength = 8;

        var expectedItems = new uint[]
        {
            189165, 41, 6, 0, 891, 2546, 64, 147
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromNineItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string?>(
            SomeString, LowerAnotherString, null, EmptyString, AnotherString,
            UpperSomeString, WhiteSpaceString, UpperAnotherString, TabString);

        const int expectedLength = 9;

        var expectedItems = new[]
        {
            SomeString, LowerAnotherString, null, EmptyString, AnotherString,
            UpperSomeString, WhiteSpaceString, UpperAnotherString, TabString
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromTenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<byte>(
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17);

        const int expectedLength = 10;

        var expectedItems = new byte[]
        {
            127, 95, 221, 54, 7, 86, 74, 1, 82, 17
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromElevenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string?>(
            "Eleventh", "Tenth", "Ninth", "Eighth", "Seventh", null,
            "Fifth", "Fourth", "Third", "Second", "First");

        const int expectedLength = 11;

        var expectedItems = new[]
        {
            "Eleventh", "Tenth", "Ninth", "Eighth", "Seventh", null,
            "Fifth", "Fourth", "Third", "Second", "First"
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromTwelveItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<int>(
            68, 982, 75, 30121, 5007, int.MinValue,
            871, Zero, 551, -3092, 27, -893);

        const int expectedLength = 12;

        var expectedItems = new[]
        {
            68, 982, 75, 30121, 5007, int.MinValue,
            871, Zero, 551, -3092, 27, -893
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromThirteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string?>(
            "First", "Second", "Third", "Fourth", "Fifth", "Sixth", string.Empty,
            "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth");

        const int expectedLength = 13;

        var expectedItems = new[]
        {
            "First", "Second", "Third", "Fourth", "Fifth", "Sixth", string.Empty,
            "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth"
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromFourteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<long>(
            -205, long.MaxValue, 78, 9717253, 27, -125, 51,
            long.MinValue, 11, 27, 95123, Zero, 82, 61);

        const int expectedLength = 14;

        var expectedItems = new[]
        {
            -205, long.MaxValue, 78, 9717253, 27, -125, 51,
            long.MinValue, 11, 27, 95123, Zero, 82, 61
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromFifteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<int>(
            71, 22, 789, int.MinValue, 157, PlusFifteen, 102937, -91,
            78612, -21, -188, Zero, int.MaxValue, PlusFifteen, 51);

        const int expectedLength = 15;

        var expectedItems = new[]
        {
            71, 22, 789, int.MinValue, 157, PlusFifteen, 102937, -91,
            78612, -21, -188, Zero, int.MaxValue, PlusFifteen, 51
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ConstructFromSixteenItems_ExpectInnerStateIsSourceItems()
    {
        var actual = new FlatArray<string?>(
            "One", "Two", "Three", "Four", "Five", null, "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", string.Empty, "Fourteen", "Fifteen", "Sixteen");

        const int expectedLength = 16;

        var expectedItems = new[]
        {
            "One", "Two", "Three", "Four", "Five", null, "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", string.Empty, "Fourteen", "Fifteen", "Sixteen"
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }
}