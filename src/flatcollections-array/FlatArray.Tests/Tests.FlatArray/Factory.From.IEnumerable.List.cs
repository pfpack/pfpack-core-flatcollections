using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromIEnumerable_List_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        IEnumerable<RefType> source = new List<RefType>();
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromIEnumerable_List_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        IEnumerable<RecordStruct?> source = new List<RecordStruct?>
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
    public void FromIEnumerable_List_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<RecordType>
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        var actual = FlatArray<RecordType>.From((IEnumerable<RecordType>)sourceList);

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