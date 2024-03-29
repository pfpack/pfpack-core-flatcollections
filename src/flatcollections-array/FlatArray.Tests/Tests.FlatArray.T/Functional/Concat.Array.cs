using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public static void ConcatWithArray_SourceIsEmptyAndOtherIsNull_ExpectEmpty()
    {
        var source = default(FlatArray<decimal?>);
        var other = (decimal?[]?)null;

        var actual = source.Concat(other);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public static void ConcatWithArray_SourceAndOtherAreEmpty_ExpectEmpty()
    {
        var source = default(FlatArray<RefType>);
        var other = Array.Empty<RefType>();

        var actual = source.Concat(other);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public static void ConcatWithArray_SourceIsEmptyAndOtherIsNotEmpty_ExpectOther()
    {
        var source = default(FlatArray<RecordType>);
        var other = new[] { MinusFifteenIdNullNameRecord, PlusFifteenIdLowerSomeStringNameRecord };

        var actual = source.Concat(other);
        var expectedItems = new[] { MinusFifteenIdNullNameRecord, PlusFifteenIdLowerSomeStringNameRecord };

        actual.VerifyTruncatedState(expectedItems);
    }

    [Fact]
    public static void ConcatWithArray_OtherIsNullAndSourceIsNotEmpty_ExpectSource()
    {
        var source = new[] { AnotherString, UpperSomeString, WhiteSpaceString, null }.InitializeFlatArray(2);
        var other = (string?[]?)null;

        var actual = source.Concat(other);
        var expectedItems = new[] { AnotherString, UpperSomeString };

        actual.VerifyTruncatedState(expectedItems);
    }

    [Fact]
    public static void ConcatWithArray_OtherIsEmptyAndSourceIsNotEmpty_ExpectSource()
    {
        var source = new RecordStruct?[]
        {
            SomeTextRecordStruct,
            AnotherTextRecordStruct,
            null,
            UpperAnotherTextRecordStruct
        }
        .InitializeFlatArray(3);

        var other = Array.Empty<RecordStruct?>();

        var actual = source.Concat(other);

        var expectedItems = new RecordStruct?[]
        {
            SomeTextRecordStruct,
            AnotherTextRecordStruct,
            null
        };

        actual.VerifyTruncatedState(expectedItems);
    }

    [Fact]
    public static void ConcatWithArray_SourceAndOtherAreNotEmpty_ExpectMergedArray()
    {
        var source = new int?[]
        {
            MinusFifteen,
            Zero,
            null,
            int.MaxValue
        }
        .InitializeFlatArray(3);

        var actual = source.Concat(PlusFifteen, null, One, int.MinValue);

        var expectedItems = new int?[]
        {
            MinusFifteen,
            Zero,
            null,
            PlusFifteen,
            null,
            One,
            int.MinValue
        };

        actual.VerifyTruncatedState(expectedItems);
    }
}