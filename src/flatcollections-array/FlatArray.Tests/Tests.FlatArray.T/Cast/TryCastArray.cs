using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public static void TryCastArray_CastIsInvalid_ExpectNull(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { PlusFifteen, Zero }.InitializeFlatArray();
        var actual = source.TryCastArray<string>();

        Assert.Null(actual);
    }

    [Theory]
    [MemberData(nameof(TryCastArray_CastValueTypeIsValid_ExpectCastedInnerState_TestSource))]
    public static void TryCastArray_CastValueTypeIsValid_ExpectCastedInnerState(
        FlatArray<int> source, uint[]? expectedItems)
    {
        var actual = source.TryCastArray<uint>();

        Assert.NotNull(actual);
        actual.Value.VerifyTruncatedState(expectedItems);
    }

    [Theory]
    [MemberData(nameof(TryCastArray_CastRefTypeIsValid_ExpectCastedInnerState_TestSource))]
    public static void TryCastArray_CastRefTypeIsValid_ExpectCastedInnerState(
        FlatArray<string?> source, object?[]? expectedItems)
    {
        var actual = source.TryCastArray<object?>();

        Assert.NotNull(actual);
        actual.Value.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int>, uint[]?> TryCastArray_CastValueTypeIsValid_ExpectCastedInnerState_TestSource
        =>
        new()
        {
            {
                default,
                default
            },
            {
                new int[] { PlusFifteen, Zero, One }.InitializeFlatArray(),
                [ PlusFifteen, Zero, One ]
            },
            {
                new int[] { int.MaxValue, One, PlusFifteen, Zero, MinusOne }.InitializeFlatArray(4),
                [ int.MaxValue, One, PlusFifteen, Zero ]
            }
        };

    public static TheoryData<FlatArray<string?>, object?[]?> TryCastArray_CastRefTypeIsValid_ExpectCastedInnerState_TestSource
        =>
        new()
        {
            {
                default,
                default
            },
            {
                new string?[] { SomeString, null }.InitializeFlatArray(),
                [ SomeString, null ]
            },
            {
                new string?[] { null, AnotherString, EmptyString, UpperAnotherString, WhiteSpaceString }.InitializeFlatArray(3),
                [ null, AnotherString, EmptyString ]
            }
        };
}