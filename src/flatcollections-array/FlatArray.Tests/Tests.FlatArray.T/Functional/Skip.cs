using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Skip_ExpectCorrectInnerState_TestSource))]
    public static void Skip_ExpectCorrectInnerState(
        FlatArray<int?> source, int count, int?[]? expectedItems)
    {
        var actual = source.Skip(count);
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int?>, int, int?[]?> Skip_ExpectCorrectInnerState_TestSource
        =>
        new()
        {
            {
                default,
                default,
                default
            },
            {
                default,
                -1,
                default
            },
            {
                default,
                -5,
                default
            },
            {
                default,
                1,
                default
            },
            {
                new int?[] { null, One, PlusFifteen, int.MinValue, MinusFifteen, int.MaxValue }.InitializeFlatArray(3),
                3,
                default
            },
            {
                new int?[] { null }.InitializeFlatArray(),
                2,
                default
            },
            {
                new int?[] { int.MaxValue, PlusFifteen, Zero }.InitializeFlatArray(2),
                default,
                [ int.MaxValue, PlusFifteen ]
            },
            {
                new int?[] { MinusFifteen }.InitializeFlatArray(),
                -1,
                [ MinusFifteen ]
            },
            {
                new int?[] { Zero, One, int.MaxValue }.InitializeFlatArray(),
                2,
                [ int.MaxValue ]
            },
            {
                new int?[] { PlusFifteen, One, null, int.MinValue, MinusFifteen, null, int.MaxValue }.InitializeFlatArray(6),
                3,
                [ int.MinValue, MinusFifteen, null ]
            }
        };
}