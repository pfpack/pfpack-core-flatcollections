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
    [MemberData(nameof(TakeRange_SourceIsEmpty_ExpectDefault_CaseSource))]
    public void TakeRange_SourceIsEmpty_ExpectDefault(FlatArray<int> source, Range range)
    {
        var actual = source.Take(range);
        actual.VerifyInnerState_Default();
    }

    public static TheoryData<FlatArray<int>, Range> TakeRange_SourceIsEmpty_ExpectDefault_CaseSource
    {
        get
        {
            IReadOnlyCollection<FlatArray<int>> sources =
            [
                default,
                new[] { MinusFifteen }.InitializeFlatArray(0),
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(0),
            ];

            IReadOnlyCollection<Range> ranges =
            [
                (..0),
                (..),
                1..,
                2..,
                int.MaxValue..,
                ^1..,
                ^2..,
                ^int.MaxValue..,
                ^0..,
                (..1),
                (..2),
                (..int.MaxValue),
                (..^1),
                (..^2),
                (..^int.MaxValue),
                ^1..0,
                ^2..0,
                ^int.MaxValue..0,
                ^1..^1,
                ^2..^2,
                ^int.MaxValue..int.MaxValue,
                1..0,
                2..0,
                2..1,
                int.MaxValue..0,
                int.MaxValue..1
            ];
            Debug.Assert(ranges.Count == ranges.Distinct().Count());

            TheoryData<FlatArray<int>, Range> result = [];
            foreach (var source in sources)
            {
                foreach (var range in ranges)
                {
                    result.Add(source, range);
                }
            }

            return result;
        }
    }
}
