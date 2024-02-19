using System;
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
        =>
        new()
        {
            { default },
            { Range.All },
            { Range.StartAt(0) },
            { Range.StartAt(1) },
            { Range.StartAt(int.MaxValue - 1) },
            { Range.StartAt(int.MaxValue) },
            { Range.EndAt(0) },
            { Range.EndAt(1) },
            { Range.EndAt(2) },
            { Range.EndAt(int.MaxValue - 1) },
            { Range.EndAt(int.MaxValue) },
            { new Range(0, 1) },
            { new Range(0, 2) },
            { new Range(0, int.MaxValue - 1) },
            { new Range(0, int.MaxValue) },
            { new Range(1, int.MaxValue - 1) },
            { new Range(1, int.MaxValue) },
            { new Range(2, int.MaxValue - 1) },
            { new Range(2, int.MaxValue) },
        };
}
