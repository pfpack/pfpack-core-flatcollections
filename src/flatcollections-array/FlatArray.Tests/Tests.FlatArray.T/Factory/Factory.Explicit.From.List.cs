using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<DateOnly>? source = null;
        var actual = FlatArray<DateOnly>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new List<RefType>();
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState_Default();
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
        sourceList.RemoveAt(1);
        sourceList.Add(MinusFifteenIdNullNameRecord);
        sourceList.Add(ZeroIdNullNameRecord);

        const int expectedLength = 3;
        var expectedItems = new[]
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }
}