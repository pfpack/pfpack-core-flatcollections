using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;
using static System.FormattableString;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Slice_SourceIsEmpty_StartLengthOutOfRange_ExpectDefault_CaseSource))]
    public void Slice_SourceIsEmpty_StartLengthOutOfRange_ExpectDefault(
        FlatArray<int> source,
        int start,
        int length)
    {
        var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => _ = source.Slice(start, length));
        var expectedMessage = Invariant(
            $"Segment must be within the array bounds. Segment start was {start}. Segment length was {length}. Array length was {source.Length}.");
        Assert.Equal(expectedMessage, actualException.Message);
    }

    public static TheoryData<FlatArray<int>, int, int> Slice_SourceIsEmpty_StartLengthOutOfRange_ExpectDefault_CaseSource
    {
        get
        {
            FlatArray<int>[] sources =
            [
                default,
                new[] { MinusFifteen }.InitializeFlatArray(0),
                new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray(0),
            ];

            IReadOnlyCollection<(int Start, int Length)> segments =
            [
                (0, 1),
                (0, int.MaxValue),
                (0, -1),
                (0, int.MinValue),
                (1, 1),
                (1, 2),
                (1, -1),
                (1, 0),
                (2, 1),
                (-1, -2),
                (-1, int.MinValue),
                (-1, 0),
                (-1, 1),
                (-1, int.MaxValue),
                (1, int.MinValue),
                (1, int.MaxValue),
                (int.MinValue, 0),
                (int.MaxValue, 0),
                (int.MinValue, int.MinValue),
                (int.MaxValue, int.MaxValue),
                (int.MaxValue, int.MinValue),
                (int.MinValue, int.MaxValue)
            ];
            Debug.Assert(segments.Distinct().Count() == segments.Count);

            TheoryData<FlatArray<int>, int, int> result = [];
            foreach (var source in sources)
            {
                foreach (var (Start, Length) in segments)
                {
                    result.Add(source, Start, Length);
                }
            }
            return result;
        }
    }
}
