using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(SliceOperator_SourceIsEmpty_InRange_ExpectCorrectResult_CaseSource))]
    public void SliceOperator_SourceIsEmpty_InRange_ExpectCorrectResult(
        FlatArray<int> source,
        Range range)
    {
        var actual = source[range];
        actual.VerifyInnerState_Default();
    }

    public static TheoryData<FlatArray<int>, Range> SliceOperator_SourceIsEmpty_InRange_ExpectCorrectResult_CaseSource
    {
        get
        {
            TheoryData<FlatArray<int>, Range> result = [];

            result.Add(
                default,
                ..);

            result.Add(
                default,
                ..0);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(0),
                ..);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(0),
                ..0);

            return result;
        }
    }
}
