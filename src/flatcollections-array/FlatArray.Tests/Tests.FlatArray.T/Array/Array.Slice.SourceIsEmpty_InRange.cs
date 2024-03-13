using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Slice_SourceIsEmpty_InRange_ExpectDefault_CaseSource))]
    public void Slice_SourceIsEmpty_InRange_ExpectDefault(FlatArray<int> source)
    {
#pragma warning disable IDE0057 // Use range operator
        var actual = source.Slice(0, 0);
#pragma warning restore IDE0057 // Use range operator
        actual.VerifyInnerState_Default();
    }

    public static TheoryData<FlatArray<int>> Slice_SourceIsEmpty_InRange_ExpectDefault_CaseSource
    {
        get
        {
            FlatArray<int>[] sources =
            [
                default,
                new[] { MinusFifteen }.InitializeFlatArray(0),
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(0),
            ];
            return new(sources);
        }
    }
}
