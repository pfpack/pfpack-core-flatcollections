using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ToArray_SourceIsDefault_ExpectEmptyArray()
    {
        var source = default(FlatArray<RecordType>);
        var actual = source.ToArray();

        Assert.Empty(actual);
        Assert.Same(Array.Empty<RecordType>(), actual);
    }

    [Fact]
    public void ToArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new RecordStruct?[]
        {
            SomeTextRecordStruct, null, default(RecordStruct), AnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatArray();
        var actual = source.ToArray();

        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ToArray_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            EmptyString, AnotherString, SomeString, LowerSomeString, WhiteSpaceString
        };

        var source = sourceItems.InitializeFlatArray(4);
        var actual = source.ToArray();

        var expected = new[]
        {
            EmptyString, AnotherString, SomeString, LowerSomeString
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToArray_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new RefType[]
        {
            PlusFifteenIdRefType, MinusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray();
        var result = source.ToArray();

        result[0] = ZeroIdRefType;
        source.VerifyInnerState(sourceItems, 2);
    }

    [Fact]
    public void ToList_SourceIsDefault_ExpectEmptyList()
    {
        var source = default(FlatArray<RecordType>);
        var actual = source.ToList();

        Assert.Empty(actual);
    }

    [Fact]
    public void ToList_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new RecordType[]
        {
            MinusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord, MinusFifteenIdNullNameRecord
        };

        var source = sourceItems.InitializeFlatArray();
        var actual = source.ToList();

        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ToList_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, null, MinusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray(2);
        var actual = source.ToList();

        var expected = new List<RefType?>
        {
            PlusFifteenIdRefType, null
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToList_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new string[]
        {
            SomeString, LowerAnotherString, EmptyString
        };

        var source = sourceItems.InitializeFlatArray();
        var result = source.ToList();

        result[1] = MixedWhiteSpacesString;
        result.Remove(SomeString);

        source.VerifyInnerState(sourceItems, 3);
    }

    [Fact]
    public void ToImmutableArray_SourceIsDefault_ExpectEmptyImmutableArray()
    {
        var source = default(FlatArray<DateOnly?>);
        var actual = source.ToImmutableArray();

        Assert.Empty(actual);
        Assert.StrictEqual(ImmutableArray<DateOnly?>.Empty, actual);
    }

    [Fact]
    public void ToImmutableArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new string[]
        {
            "One", "Two", "Three", "Four", "Five"
        };

        var source = sourceItems.InitializeFlatArray();
        var actual = source.ToImmutableArray();

        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ToImmutableArray_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatArray(1);

        var actual = source.ToImmutableArray();
        var expected = new[] { SomeTextRecordStruct }.ToImmutableArray();

        Assert.Equal<IEnumerable<RecordStruct>>(expected, actual);
    }
}