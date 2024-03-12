using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(SliceOperator_InRange_ExpectCorrectResult_CaseSource))]
    public void SliceOperator_InRange_ExpectCorrectResult(
        FlatArray<int> source,
        Range range,
        int[]? expectedItems)
    {
        var actual = source[range];
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int>, Range, int[]?> SliceOperator_InRange_ExpectCorrectResult_CaseSource
    {
        get
        {
            TheoryData<FlatArray<int>, Range, int[]?> result = [];

            result.Add(
                default,
                ..,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(0),
                ..,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                ..0,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                1..,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                ..,
                [MinusFifteen]);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(),
                1..2,
                [PlusFifteen]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray(),
                1..3,
                [MinusOne, Zero]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MinValue }.InitializeFlatArray(5),
                ..3,
                [MinusFifteen, MinusOne, Zero]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MaxValue }.InitializeFlatArray(5),
                1..,
                [MinusOne, Zero, One, PlusFifteen]);

            return result;
        }
    }
}
