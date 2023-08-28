using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.Core.Tests.TestData;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
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
    [MemberData(nameof(ReadingCollectionsTestSource.EnumerateStringNonEmptyCases), MemberType = typeof(ReadingCollectionsTestSource))]
    public void FromEnumerable_SourceIsNotEmpty_ExpectInnerStateCorrespondsToSource(
        string?[] sourceItems, string?[] expectedItems)
    {
        var source = GetSource();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(expectedItems, sourceItems.Length);

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