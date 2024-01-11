using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Take_ExpectCorrectInnerState_TestSource))]
    public static void Take_ExpectCorrectInnerState(
        FlatArray<string?> source, int count, string?[]? expectedItems)
    {
        var actual = source.Take(count);
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<string?>, int, string?[]?> Take_ExpectCorrectInnerState_TestSource
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
                new string?[] { SomeString, AnotherString }.InitializeFlatArray(),
                default,
                default
            },
            {
                new string?[] { SomeString, AnotherString }.InitializeFlatArray(1),
                -1,
                default
            },
            {
                new string?[] { null }.InitializeFlatArray(),
                1,
                [ null ]
            },
            {
                new string?[] { UpperAnotherString, EmptyString, SomeString, WhiteSpaceString, AnotherString }.InitializeFlatArray(3),
                4,
                [ UpperAnotherString, EmptyString, SomeString ]
            },
            {
                new string?[] { AnotherString, MixedWhiteSpacesString, EmptyString, null, SomeString }.InitializeFlatArray(4),
                2,
                [ AnotherString, MixedWhiteSpacesString ]
            }
        };
}