using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                (..^3, null),
                (..^4, null),
                (..^int.MaxValue, null),
                (3..,  null),
                (3..int.MaxValue, null),
                (1..1, null),
                (2..2, null),
                (2..1, null),
                (3..3, null),
                (3..2, null),
                (1..^2, null),
                (2..^1, null),
                (2..^2, null),
                (3..^1, null),
                (^1..1, null),
                (^0..2, null),
                (^0..1, null),
                (^1..^2, null),
                (^0..^1, null),
                (^0..^2, null),
                (.., new[] { MinusFifteen, MinusOne, Zero }),
                (..3, new[] { MinusFifteen, MinusOne, Zero }),
                (..4, new[] { MinusFifteen, MinusOne, Zero }),
                (..int.MaxValue, new[] { MinusFifteen, MinusOne, Zero }),
            ];
            DebugAssertUniqueCases();

            TheoryData<FlatArray<int>, Range, int[]?> result = [];
            foreach (var source in sources)
            {
                foreach (var (range, expectedItems) in rangeExpectedItemsPairs)
                {
                    result.Add(source, range, expectedItems);
                }
            }

            return result;

            void DebugAssertUniqueCases()
            {
                var uniquePairs = rangeExpectedItemsPairs.Aggregate(
                    new List<(Range Range, int[]? ExpectedItems)>(),
                    (accumulate, current) =>
                    {
                        if (accumulate.Exists(
                            pair => DebugAssertUniqueCases_Equal(current, pair)) is false)
                        {
                            accumulate.Add(current);
                        }
                        return accumulate;
                    });

                Debug.Assert(rangeExpectedItemsPairs.Count == uniquePairs.Count);
            }

            static bool DebugAssertUniqueCases_Equal(
                (Range Range, int[]? ExpectedItems) x,
                (Range Range, int[]? ExpectedItems) y)
            {
                if (x.Range.Equals(y.Range) is false)
                {
                    return false;
                }

                if (x.ExpectedItems is null && y.ExpectedItems is null)
                {
                    return true;
                }

                if (x.ExpectedItems is null || y.ExpectedItems is null)
                {
                    return false;
                }

                return x.ExpectedItems.SequenceEqual(y.ExpectedItems);
            }
        }
    }
}
