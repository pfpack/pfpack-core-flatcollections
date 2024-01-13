using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
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
}