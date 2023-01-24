using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        object?[]? source = null;
        var actual = FlatArray<object?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<StructType>();
        var actual = FlatArray<StructType>.From(source);

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
        var actual = FlatArray<int?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray<string>.From(sourceArray);

        sourceArray[1] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RefType>);
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, null, SomeString, EmptyString, WhiteSpaceString)]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType>? source = default(FlatArray<RecordType>);
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<bool?>? source = new bool?[] { false, null, true }.InitializeFlatArray();

        var actual = FlatArray<bool?>.From(source);
        var expectedItems = new bool?[] { false, null, true };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<DateOnly>? source = null;
        var actual = FlatArray<DateOnly>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new List<RefType>();
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var source = new List<RecordStruct?>
        {
            SomeTextRecordStruct, null, AnotherTextRecordStruct
        };

        var actual = FlatArray<RecordStruct?>.From(source);

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

        var actual = FlatArray<RecordType>.From(sourceList);

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
        var actual = FlatArray<long?>.From(source);

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
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RecordType>? source = null;
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = new ImmutableArray<RefType?>();;
        var actual = FlatArray<RefType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(null, MinusFifteen, Zero)]
    public void FromNullableImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params int?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = sourceItems.ToImmutableArray();
        var actual = FlatArray<int?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromEnumerable_SourceIsNull_ExpectInnerStateIsDefault()
    {
        IEnumerable<DateTime>? source = null;
        var actual = FlatArray<DateTime>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromEnumerable_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Enumerable.Empty<RefType?>();
        var actual = FlatArray<RefType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(AnotherString)]
    [InlineData(null, AnotherString)]
    [InlineData(AnotherString, null)]
    [InlineData(null, null)]
    [InlineData("01")]
    [InlineData("01", "02")]
    [InlineData("01", "02", "03")]
    [InlineData("01", "02", "03", "04")]
    [InlineData("01", "02", "03", "04", "05")]
    [InlineData("01", "02", "03", "04", "05", "06")]
    [InlineData("01", "02", "03", "04", "05", "06", "07")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17")]
    public void FromEnumerable_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params string?[] sourceItems)
    {
        var copied = sourceItems.GetCopy();

        var source = GetSource();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(copied, copied.Length);

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
        var source = new StubCollection<StructType?>(new());
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RefType?>
        {
            PlusFifteenIdRefType, ZeroIdRefType, null
        };

        var source = new StubCollection<RefType?>(sourceItems);
        var actual = FlatArray<RefType?>.From(source);

        var expectedItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType, null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromCollection_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<StructType>
        {
            SomeTextStructType, default
        };

        var source = new StubCollection<StructType>(sourceList);
        var actual = FlatArray<StructType>.From(source);

        source.Remove(SomeTextStructType);

        var expectedItems = new[]
        {
            SomeTextStructType, default
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromReadOnlyList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new StubReadOnlyList<RefType>(new());
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromReadOnlyList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RecordStruct>
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        var source = new StubReadOnlyList<RecordStruct>(sourceItems);
        var actual = FlatArray<RecordStruct>.From(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromReadOnlyCollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var sourceItems = Array.Empty<string?>();
        var source = new StubReadOnlyCollection<string?>(sourceItems);

        var actual = FlatArray<string?>.From(source);
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromReadOnlyCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            null, PlusFifteenIdRefType, ZeroIdRefType
        };

        var source = new StubReadOnlyCollection<RefType?>(sourceItems);
        var actual = FlatArray<RefType?>.From(source);

        var expectedItems = new[]
        {
            null, PlusFifteenIdRefType, ZeroIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}