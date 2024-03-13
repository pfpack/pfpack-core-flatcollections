using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;
using static System.FormattableString;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Slice_SourceNotEmpty_OutOfRange_ExpectArgumentOutOfRangeException_CaseSource))]
    public void Slice_SourceNotEmpty_OutOfRange_ExpectArgumentOutOfRangeException(
        FlatArray<int> source,
        int start,
        int length)
    {
        var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => _ = source.Slice(start, length));
        var expectedMessage = Invariant(
            $"Segment must be within the array bounds. Segment start was {start}. Segment length was {length}. Array length was {source.Length}.");
        Assert.Equal(expectedMessage, actualException.Message);
    }

    public static TheoryData<FlatArray<int>, int, int> Slice_SourceNotEmpty_OutOfRange_ExpectArgumentOutOfRangeException_CaseSource
    {
        get
        {
            TheoryData<FlatArray<int>, int, int> result = [];

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                -1, 0);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                0, 2);

            result.Add(
                new[] { MinusFifteen }.InitializeFlatArray(),
                2, 0);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(),
                2, 1);

            result.Add(
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(),
                3, 1);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray(),
                5, int.MaxValue);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MinValue }.InitializeFlatArray(5),
                4, 2);

            result.Add(
                new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen, int.MaxValue }.InitializeFlatArray(5),
                int.MinValue, int.MaxValue);

            return result;
        }
    }
}
