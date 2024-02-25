using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(TakeRange_SourceIsEmpty_ExpectEmpty_CaseSource))]
    public void TakeRange_SourceIsEmpty_ExpectEmpty(Range range)
    {
        FlatArray<int> source = default;
        var actual = source.Take(range);
        actual.VerifyInnerState_Default();
    }

    public static TheoryData<Range> TakeRange_SourceIsEmpty_ExpectEmpty_CaseSource
    {
        get
        {
            Range[] source =
            [
                0..0,
                (..),
                1..,
                2..,
                int.MaxValue..,
                ^1..,
                ^2..,
                ^int.MaxValue..,
                ^0..,
                (..0),
                (..1),
                (..2),
                (..int.MaxValue),
                (..^1),
                (..^2),
                (..^int.MaxValue),
                0..^1,
                0..^2,
                0..^int.MaxValue,
                ^1..0,
                ^2..0,
                ^int.MaxValue..0,
                ^1..^1,
                ^2..^2,
                ^int.MaxValue..int.MaxValue,
            ];

            Debug.Assert(source.Length == source.Distinct().Count());

            return new(source);
        }
    }

}
