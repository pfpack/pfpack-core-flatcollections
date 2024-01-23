using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(TrimExcess_ExpectTrimmedInnerState_TestSource))]
    public static void TrimExcess_ExpectTrimmedInnerState(
        FlatArray<string?> source, string?[]? expectedItems, int expectedLength)
    {
        var actual = source.TrimExcess();
        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    public static TheoryData<FlatArray<string?>, string?[]?, int> TrimExcess_ExpectTrimmedInnerState_TestSource
        =>
        new()
        {
            {
                default,
                default,
                default
            },
            {
                new[] { WhiteSpaceString, null, SomeString }.InitializeFlatArray(0),
                default,
                default
            },
            {
                new[] { WhiteSpaceString, null, SomeString }.InitializeFlatArray(3),
                [ WhiteSpaceString, null, SomeString ],
                3
            },
            {
                new[] { null, SomeString, MixedWhiteSpacesString, TabString, AnotherString, LowerSomeString }.InitializeFlatArray(4),
                [ null, SomeString, MixedWhiteSpacesString, TabString ],
                4
            }
        };
}