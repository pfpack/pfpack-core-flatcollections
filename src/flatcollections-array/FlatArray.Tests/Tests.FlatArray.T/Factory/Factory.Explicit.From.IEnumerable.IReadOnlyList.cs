using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromIEnumerable_IReadOnlyList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new StubReadOnlyList<RefType>(new());
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromIEnumerable_IReadOnlyList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
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
}