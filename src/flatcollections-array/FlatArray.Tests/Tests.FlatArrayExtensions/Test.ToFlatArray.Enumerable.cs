using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.Core.Tests.TestData;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsNullEnumerable_ExpectInnerStateIsDefault()
    {
        IEnumerable<RefType?>? source = null;
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsEmptyEnumerable_ExpectInnerStateIsDefault()
    {
        var source = Enumerable.Empty<StructType?>();
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [MemberData(nameof(ReadingCollectionsTestSource.EnumerateStringNonEmptyCases), MemberType = typeof(ReadingCollectionsTestSource))]
    public void ToFlatArray_FromEnumerable_SourceIsNotEmpty_ExpectInnerStateCorrespondsToSource(
        string?[] sourceItems, string?[] expectedItems)
    {
        var source = GetSource();
        var actual = source.ToFlatArray();

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
    public void ToFlatArray_SourceIsEmptyCollection_ExpectInnerStateIsDefault()
    {
        var source = new StubCollection<RecordType>(new());
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyCollection_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<StructType?>
        {
            SomeTextStructType, null
        };

        var source = new StubCollection<StructType?>(sourceItems);
        var actual = source.ToFlatArray();

        var expectedItems = new StructType?[]
        {
            SomeTextStructType, null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ToFlatArray_ThenModifySourceCollection_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<RefType>
        {
            MinusFifteenIdRefType, ZeroIdRefType, PlusFifteenIdRefType
        };

        var source = new StubCollection<RefType>(sourceList);
        var actual = source.ToFlatArray();

        source.Add(new());

        var expectedItems = new[]
        {
            MinusFifteenIdRefType, ZeroIdRefType, PlusFifteenIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ToFlatArray_SourceIsEmptyReadOnlyList_ExpectInnerStateIsDefault()
    {
        var source = new StubReadOnlyList<DateOnly?>(new());
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyReadOnlyList_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RecordType>
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, MinusFifteenIdSomeStringNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        var source = new StubReadOnlyList<RecordType>(sourceItems);
        var actual = source.ToFlatArray();

        var expectedItems = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, MinusFifteenIdSomeStringNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ToFlatArray_SourceIsEmptyReadOnlyCollection_ExpectInnerStateIsDefault()
    {
        var sourceItems = new List<StructType>();
        var source = new StubReadOnlyCollection<StructType>(sourceItems);

        var actual = source.ToFlatArray();
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyReadOnlyCollection_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<string?>
        {
            EmptyString, SomeString, null, UpperAnotherString, AnotherString
        };

        var source = new StubReadOnlyCollection<string?>(sourceItems);
        var actual = source.ToFlatArray();

        var expectedItems = new[]
        {
            EmptyString, SomeString, null, UpperAnotherString, AnotherString
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}