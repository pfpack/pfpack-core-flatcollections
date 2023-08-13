using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public static void Concat_SourceAndOtherAreEmpty_ExpectEmpty()
    {
        var source = default(FlatArray<StructType>);
        var other = default(FlatArray<StructType>);

        var actual = source.Concat(other);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public static void Concat_SourceIsEmptyAndOtherIsNotEmpty_ExpectOther()
    {
        var source = default(FlatArray<int?>);
        var other = new int?[] { null, PlusFifteen, Zero, One }.InitializeFlatArray(3);

        var actual = source.Concat(other);
        var expectedItems = new int?[] { null, PlusFifteen, Zero };

        actual.VerifyTruncatedState(expectedItems);
    }

    [Fact]
    public static void Concat_OtherIsEmptyAndSourceIsNotEmpty_ExpectSource()
    {
        var source = new[] { SomeString, null, AnotherString }.InitializeFlatArray(2);
        var other = default(FlatArray<string?>);

        var actual = source.Concat(other);
        var expectedItems = new[] { SomeString, null };

        actual.VerifyTruncatedState(expectedItems);
    }

    [Fact]
    public static void Concat_SourceAndOtherAreNotEmpty_ExpectMergedArray()
    {
        var source = new[]
        {
            null,
            MinusFifteenIdNullNameRecord,
            ZeroIdNullNameRecord
        }
        .InitializeFlatArray(2);

        var other = new[]
        {
            PlusFifteenIdLowerSomeStringNameRecord,
            MinusFifteenIdSomeStringNameRecord,
            PlusFifteenIdSomeStringNameRecord,
            MinusFifteenIdNullNameRecord,
            null
        }
        .InitializeFlatArray(3);

        var actual = source.Concat(other);

        var expectedItems = new[]
        {
            null,
            MinusFifteenIdNullNameRecord,
            PlusFifteenIdLowerSomeStringNameRecord,
            MinusFifteenIdSomeStringNameRecord,
            PlusFifteenIdSomeStringNameRecord
        };

        actual.VerifyTruncatedState(expectedItems);
    }
}