using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        StructType[]? source = null;
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType?>();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, null, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, null, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int?[] source)
    {
        var coppied = source.GetCopy();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromArray_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray.From(sourceArray);

        sourceArray[1] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RecordType>);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, TabString, SomeString, EmptyString, WhiteSpaceString)]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<long>? source = default(FlatArray<long>);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<string>? source = new[] { SomeString, AnotherString, TabString }.InitializeFlatArray(2);

        var actual = FlatArray.From(source);
        var expectedItems = new[] { SomeString, AnotherString };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<byte?>? source = null;
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new List<object?>();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var source = new List<RefType>
        {
            MinusFifteenIdRefType, ZeroIdRefType
        };

        var actual = FlatArray.From(source);

        const int expectedLength = 2;
        var expectedItems = new[]
        {
            MinusFifteenIdRefType, ZeroIdRefType
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

        var actual = FlatArray.From(sourceList);

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
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(LowerSomeString, null, AnotherString)]
    public void FromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.ToImmutableArray();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = null;
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<StructType>? source = new ImmutableArray<StructType>();;
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(One)]
    [InlineData(MinusFifteen, Zero, PlusFifteen)]
    public void FromNullableImmutableArray_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params int[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = sourceItems.ToImmutableArray();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromEnumerable_SourceIsNull_ExpectInnerStateIsDefault()
    {
        IEnumerable<DateOnly>? source = null;
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromEnumerable_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Enumerable.Empty<RecordType>();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData("01", "02", "03", "04", "05", "06", null, "08", "09", "10", "11", "12")]
    public void FromEnumerable_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params string?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = GetSource();
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);

        IEnumerable<string?> GetSource()
        {
            foreach (var item in sourceItems)
            {
                yield return item;
            }
        }
    }

    [Fact]
    public void FromCollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new StubCollection<RefType>(new());
        var actual = FlatArray.From<RefType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RecordStruct>
        {
            SomeTextRecordStruct, default, AnotherTextRecordStruct
        };

        var source = new StubCollection<RecordStruct>(sourceItems);
        var actual = FlatArray.From<RecordStruct>(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, default, AnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromCollection_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<StructType?>
        {
            null, SomeTextStructType
        };

        var source = new StubCollection<StructType?>(sourceList);
        var actual = FlatArray.From<StructType?>(source);

        source.Remove(SomeTextStructType);

        var expectedItems = new StructType?[]
        {
            null, SomeTextStructType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromReadOnlyList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new StubReadOnlyList<string?>(new());
        var actual = FlatArray.From<string?>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromReadOnlyList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RecordStruct>
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        var source = new StubCollection<RecordStruct>(sourceItems);
        var actual = FlatArray.From<RecordStruct>(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromReadOnlyCollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var sourceItems = Array.Empty<long>();
        var source = new StubReadOnlyCollection<long>(sourceItems);

        var actual = FlatArray.From<long>(source);
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromReadOnlyCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            ZeroIdRefType, PlusFifteenIdRefType
        };

        var source = new StubReadOnlyCollection<RefType>(sourceItems);
        var actual = FlatArray.From<RefType>(source);

        var expectedItems = new[]
        {
            ZeroIdRefType, PlusFifteenIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}