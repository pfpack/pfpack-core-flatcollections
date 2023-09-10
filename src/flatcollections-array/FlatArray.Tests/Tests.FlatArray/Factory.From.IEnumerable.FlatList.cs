using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromIEnumerable_FlatList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType>().InitializeFlatListAsEnumerable();
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromIEnumerable_FlatList_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatListAsEnumerable();
        var actual = FlatArray<RecordStruct>.From(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromIEnumerable_FlatList_SourceIsNotEmpty_ItemsLengthIsGreaterThenEffectiveLength_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatListAsEnumerable(sourceItems.Length - 1);
        var actual = FlatArray<RecordStruct>.From(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}