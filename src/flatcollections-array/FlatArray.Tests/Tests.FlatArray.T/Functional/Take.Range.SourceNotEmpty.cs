using System;
using System.Collections.Generic;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(TakeRange_SourceNotEmpty_ExpectCorrectInnerState_CaseSource))]
    public void TakeRange_SourceNotEmpty_ExpectCorrectInnerState(
        FlatArray<int> source, Range range, int[]? expectedItems)
    {
        var actual = source.Take(range);
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int>, Range, int[]?> TakeRange_SourceNotEmpty_ExpectCorrectInnerState_CaseSource
    {
        get
        {
            IReadOnlyCollection<FlatArray<int>> sources =
            [
                new[] { MinusFifteen, MinusOne, Zero }.InitializeFlatArray(3),
                new[] { MinusFifteen, MinusOne, Zero, One }.InitializeFlatArray(3),
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray(3),
            ];

            IReadOnlyCollection<(Range Range, int[]? ExpectedItems)> rangeExpectedItemsPairs =
            [
                (..0, null),
                (.., new[] { MinusFifteen, MinusOne, Zero }),
            ];

            TheoryData<FlatArray<int>, Range, int[]?> result = [];
            foreach (var source in sources)
            {
                foreach (var (range, expectedItems) in rangeExpectedItemsPairs)
                {
                    result.Add(source, range, expectedItems);
                }
            }

            return result;
        }
    }
}
