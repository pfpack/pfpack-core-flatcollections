using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(SliceOperator_OutOfRange_ExpectArgumentOutOfRangeException_CaseSource))]
    public void SliceOperator_OutOfRange_ExpectArgumentOutOfRangeException(
        FlatArray<int> source,
        Range range)
    {
        var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => _ = source[range]);
        Assert.StartsWith("Segment must be within the array bounds.", actualException.Message);
    }

    public static TheoryData<FlatArray<int>, Range> SliceOperator_OutOfRange_ExpectArgumentOutOfRangeException_CaseSource
    {
        get
        {
            TheoryData<FlatArray<int>, Range> result = [];

            result.Add(
                default,
                ..1);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(0),
                1..2);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(),
                ..3);

            result.Add(
                new[] { MinusFifteen, PlusFifteen, MinusOne, One }.InitializeFlatArray(3),
                1..4);

            return result;
        }
    }
}
