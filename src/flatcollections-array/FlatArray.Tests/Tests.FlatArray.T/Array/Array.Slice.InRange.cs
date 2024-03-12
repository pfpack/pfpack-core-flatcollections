using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Slice_InRange_ExpectCorrectResult_CaseSource))]
    public void Slice_InRange_ExpectCorrectResult(
        FlatArray<int> source,
        int start,
        int length,
        int[]? expectedItems)
    {
        var actual = source.Slice(start, length);
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int>, int, int, int[]?> Slice_InRange_ExpectCorrectResult_CaseSource
    {
        get
        {
            TheoryData<FlatArray<int>, int, int, int[]?> result = [];

            result.Add(
                default,
                0, 0,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(0),
                0, 0,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                0, 0,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                1, 0,
                null);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                0, 1,
                [MinusFifteen]);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(),
                1, 1,
                [PlusFifteen]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray(),
                1, 2,
                [MinusOne, Zero]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MinValue }.InitializeFlatArray(5),
                0, 3,
                [MinusFifteen, MinusOne, Zero]);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MaxValue }.InitializeFlatArray(5),
                1, 4,
                [MinusOne, Zero, One, PlusFifteen]);

            return result;
        }
    }
}
