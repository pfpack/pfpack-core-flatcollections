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
                (3.., null),
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
                (^1..^1, null),
                (^int.MaxValue..^(int.MaxValue - 1), null),
                (^int.MaxValue..^int.MaxValue, null),
                (^(int.MaxValue - 1)..^int.MaxValue, null),
                (^3..^3, null),
                (^3..^4, null),
                (^3..^int.MaxValue, null),
                (^4..^3, null),
                (^4..^4, null),
                (^4..^int.MaxValue, null),
                (3..4, null),
                (3..5, null),
                (1..0, null),
                (2..0, null),
                (2..^3, null),
                (2..^4, null),
                (2..^int.MaxValue, null),
                (^2..0, null),
                (^2..^2, null),
                (^2..^3, null),
                (^2..^4, null),
                (^2..^int.MaxValue, null),
                (4..6, null),
                (4..int.MaxValue, null),
                (6..4, null),
                (int.MaxValue..4, null),
                (int.MaxValue..^int.MaxValue, null),
                (1..^3, null),
                (1..^4, null),
                (1..^int.MaxValue, null),
                (100..^200, null),
                (200..100, null),
                (^100..^int.MaxValue, null),
                (^int.MaxValue..^100, null),
                (.., new[] { MinusFifteen, MinusOne, Zero }),
                (..3, new[] { MinusFifteen, MinusOne, Zero }),
                (..4, new[] { MinusFifteen, MinusOne, Zero }),
                (..int.MaxValue, new[] { MinusFifteen, MinusOne, Zero }),
                (^3..3, new[] { MinusFifteen, MinusOne, Zero }),
                (^4..4, new[] { MinusFifteen, MinusOne, Zero }),
                (^int.MaxValue..int.MaxValue, new[] { MinusFifteen, MinusOne, Zero }),
                (..2, new[] { MinusFifteen, MinusOne }),
                (^3..2, new[] { MinusFifteen, MinusOne }),
                (^4..2, new[] { MinusFifteen, MinusOne }),
                (^int.MaxValue..2, new[] { MinusFifteen, MinusOne}),
                (..^1, new[] { MinusFifteen, MinusOne }),
                (^3..^1, new[] { MinusFifteen, MinusOne }),
                (^4..^1, new[] { MinusFifteen, MinusOne }),
                (^int.MaxValue..^1, new[] { MinusFifteen, MinusOne}),
                (1.., new[] { MinusOne, Zero }),
                (1..3, new[] { MinusOne, Zero }),
                (1..4, new[] { MinusOne, Zero }),
                (1..int.MaxValue, new[] { MinusOne, Zero }),
                (^2.., new[] { MinusOne, Zero }),
                (^2..3, new[] { MinusOne, Zero }),
                (^2..4, new[] { MinusOne, Zero }),
                (^2..int.MaxValue, new[] { MinusOne, Zero }),
                (1..2, new[] { MinusOne }),
                (1..^1, new[] { MinusOne }),
                (^2..2, new[] { MinusOne }),
                (^2..^1, new[] { MinusOne }),
                (..1, new[] { MinusFifteen }),
                (..^2, new[] { MinusFifteen }),
                (^3..1, new[] { MinusFifteen }),
                (^3..^2, new[] { MinusFifteen }),
                (2.., new[] { Zero }),
                (2..int.MaxValue, new[] { Zero }),
                (^1.., new[] { Zero }),
                (^1..int.MaxValue, new[] { Zero }),
            ];
            DebugAssertUniqueCases(rangeExpectedItemsPairs);

            TheoryData<FlatArray<int>, Range, int[]?> result = [];
            foreach (var source in sources)
            {
                foreach (var (range, expectedItems) in rangeExpectedItemsPairs)
                {
                    result.Add(source, range, expectedItems);
                }
            }

            return result;

            static void DebugAssertUniqueCases(
                IReadOnlyCollection<(Range Range, int[]? ExpectedItems)> testCases)
            {
                List<(Range Range, int[]? ExpectedItems)> uniquePairs = [];
                foreach (var testCase in testCases)
                {
                    if (uniquePairs.Exists(pair => DebugAssertUniqueCases_Equal(testCase, pair)) is false)
                    {
                        uniquePairs.Add(testCase);
                    }
                }
                Debug.Assert(testCases.Count == uniquePairs.Count);
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
