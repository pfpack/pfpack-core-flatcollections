using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Theory]
    [MemberData(nameof(CastUp_ExpectCorrectInnerState_TestSource))]
    public static void CastUp_ExpectCorrectInnerState(
        FlatArray<string?> source, object?[]? expectedItems)
    {
        var actual = FlatArray.CastUp<object?, string?>(source);
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<string?>, object?[]?> CastUp_ExpectCorrectInnerState_TestSource
        =>
        new()
        {
            {
                default,
                default
            },
            {
                new string?[] { SomeString, EmptyString }.InitializeFlatArray(),
                [ SomeString, EmptyString ]
            },
            {
                new string?[] { AnotherString, UpperSomeString, null, WhiteSpaceString, SomeString, TabString }.InitializeFlatArray(5),
                [ AnotherString, UpperSomeString, null, WhiteSpaceString, SomeString]
            }
        };
}