using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderStaticTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        RecordType?[]? source = null;
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType?>(), default);
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RecordStruct?>();
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordStruct?>(), default);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, null, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, null, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int?[] source)
    {
        var coppied = source.GetCopy();
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromArray_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray.Builder.From(sourceArray);

        sourceArray[1] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RecordType>);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Fact]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        var source = new[] { MinusFifteenIdRefType, null, ZeroIdRefType, PlusFifteenIdRefType }.InitializeFlatArray(3);

        var actual = FlatArray.Builder.From(source);
        var expectedItems = new[] { MinusFifteenIdRefType, null, ZeroIdRefType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<object>?);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<object>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType?>? source = default(FlatArray<RecordType?>);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType?>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<string>? source = new[] { SomeString, AnotherString }.InitializeFlatArray();

        var actual = FlatArray<string>.From(source);
        var expectedItems = new[] { SomeString, AnotherString };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<byte?>? source = null;
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<byte?>(), default);
    }

    [Fact]
    public void FromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new List<RecordType>();
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Fact]
    public void FromList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var source = new List<long?>
        {
            long.MinValue, 0, null, -31
        };

        var actual = FlatArray.Builder.From(source);

        const int expectedLength = 4;
        var expectedItems = new long?[]
        {
            long.MinValue, 0, null, -31
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromList_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<RecordType>
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        var actual = FlatArray.Builder.From(sourceList);

        sourceList[0] = PlusFifteenIdLowerSomeStringNameRecord;
        sourceList.Add(MinusFifteenIdNullNameRecord);

        var expectedItems = new[]
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<RecordStruct?>);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordStruct?>(), default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(LowerSomeString, null, AnotherString)]
    public void FromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.ToImmutableArray();
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = null;
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType?>(), default);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<StructType>? source = new ImmutableArray<StructType>();;
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType>(), default);
    }

    [Theory]
    [InlineData(One)]
    [InlineData(MinusFifteen, Zero, PlusFifteen)]
    public void FromNullableImmutableArray_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params int[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = sourceItems.ToImmutableArray();
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }
}