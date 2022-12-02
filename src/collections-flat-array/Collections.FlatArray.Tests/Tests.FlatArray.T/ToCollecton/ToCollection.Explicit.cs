using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ToArray_SourceIsDefault_ExpectEmptyArray()
    {
        var source = default(FlatArray<RecordType>);

        var actual = source.ToArray();
        var expected = Array.Empty<RecordType>();

        Assert.Equal(expected, actual);
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
    public void ToArray_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new RefType[]
        {
            PlusFifteenIdRefType, MinusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray();
        var result = source.ToArray();

        result[0] = ZeroIdRefType;
        TestHelper.VerifyInnerState(2, sourceItems, source);
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

        TestHelper.VerifyInnerState(3, sourceItems, source);
    }

    [Fact]
    public void ToImmutableArray_SourceIsDefault_ExpectEmptyImmutableArray()
    {
        var source = default(FlatArray<DateOnly?>);

        var actual = source.ToImmutableArray();
        var expected = ImmutableArray<DateOnly?>.Empty;

        Assert.StrictEqual(expected, actual);
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
}