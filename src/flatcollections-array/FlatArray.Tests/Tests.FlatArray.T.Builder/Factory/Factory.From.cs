using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        StructType[]? source = null;
        var actual = FlatArray<StructType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType>(), default);
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RecordType>();
        var actual = FlatArray<RecordType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, Zero, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, 975, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int[] source)
    {
        var coppied = source.GetCopy();
        var actual = FlatArray<int>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray<string>.Builder.From(sourceArray);

        sourceArray[0] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RefType>);
        var actual = FlatArray<RefType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType>(), default);
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, null, SomeString, EmptyString, WhiteSpaceString)]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = FlatArray<string?>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = FlatArray<StructType?>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType?>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType>? source = default(FlatArray<RecordType>);
        var actual = FlatArray<RecordType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<bool?>? source = new bool?[] { false, null, true }.InitializeFlatArray(2);

        var actual = FlatArray<bool?>.Builder.From(source);
        var expectedItems = new bool?[] { false, null };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<DateOnly>? source = null;
        var actual = FlatArray<DateOnly>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<DateOnly>(), default);
    }

    [Fact]
    public void FromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new List<RefType>();
        var actual = FlatArray<RefType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType>(), default);
    }

    [Fact]
    public void FromList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var source = new List<RecordStruct?>
        {
            SomeTextRecordStruct, null, AnotherTextRecordStruct
        };

        var actual = FlatArray<RecordStruct?>.Builder.From(source);

        const int expectedLength = 3;
        var expectedItems = new RecordStruct?[]
        {
            SomeTextRecordStruct, null, AnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromList_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<RecordType>
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        var actual = FlatArray<RecordType>.Builder.From(sourceList);

        sourceList[0] = PlusFifteenIdLowerSomeStringNameRecord;
        sourceList.Add(MinusFifteenIdNullNameRecord);

        const int expectedLength = 3;
        var expectedItems = new[]
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<long?>);
        var actual = FlatArray<long?>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<long?>(), default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(LowerSomeString, null, AnotherString)]
    public void FromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.ToImmutableArray();
        var actual = FlatArray<string?>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RecordType>? source = null;
        var actual = FlatArray<RecordType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = new ImmutableArray<RefType?>();;
        var actual = FlatArray<RefType?>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType?>(), default);
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(null, MinusFifteen, Zero)]
    public void FromNullableImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params int?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = sourceItems.ToImmutableArray();
        var actual = FlatArray<int?>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }
}