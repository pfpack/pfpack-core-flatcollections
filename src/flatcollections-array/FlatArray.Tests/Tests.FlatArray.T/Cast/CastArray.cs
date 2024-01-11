using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public static void CastArray_CastIsInvalid_ExpectInvalidCastException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { PlusFifteen, Zero }.InitializeFlatArray();
        _ = Assert.Throws<InvalidCastException>(Test);

        void Test()
            =>
            _ = source.CastArray<string>();
    }

    [Theory]
    [MemberData(nameof(CastArray_CastValueTypeIsValid_ExpectCastedInnerState_TestSource))]
    public static void CastArray_CastValueTypeIsValid_ExpectCastedInnerState(
        FlatArray<int> source, uint[]? expectedItems)
    {
        var actual = source.CastArray<uint>();
        actual.VerifyTruncatedState(expectedItems);
    }

    [Theory]
    [MemberData(nameof(CastArray_CastRefTypeIsValid_ExpectCastedInnerState_TestSource))]
    public static void CastArray_CastRefTypeIsValid_ExpectCastedInnerState(
        FlatArray<string?> source, object?[]? expectedItems)
    {
        var actual = source.CastArray<object?>();
        actual.VerifyTruncatedState(expectedItems);
    }

    public static TheoryData<FlatArray<int>, uint[]?> CastArray_CastValueTypeIsValid_ExpectCastedInnerState_TestSource
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

    public static TheoryData<FlatArray<string?>, object?[]?> CastArray_CastRefTypeIsValid_ExpectCastedInnerState_TestSource
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