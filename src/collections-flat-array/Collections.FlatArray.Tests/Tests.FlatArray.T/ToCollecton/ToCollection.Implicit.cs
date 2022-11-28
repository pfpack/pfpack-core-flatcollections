using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitToArray_SourceIsDefault_ExpectEmptyArray()
    {
        StructType[] actual = default(FlatArray<StructType>);
        var expected = Array.Empty<StructType>();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ImplicitToArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new RefType[]
        {
            ZeroIdRefType, PlusFifteenIdRefType
        };

        RefType[] actual = TestHelper.Initialize(sourceItems);
        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ImplicitToArray_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            MinusOne, PlusFifteen, Zero
        };

        var source = TestHelper.Initialize(sourceItems);
        int[] result = source;

        result[2] += 1;
        TestHelper.VerifyInnerState(3, sourceItems, source);
    }

    [Fact]
    public void ImplicitToList_SourceIsDefault_ExpectEmptyList()
    {
        List<string?> actual = default(FlatArray<string?>);
        Assert.Empty(actual);
    }

    [Fact]
    public void ImplicitToList_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new bool?[]
        {
            false, null, true
        };

        List<bool?> actual = TestHelper.Initialize(sourceItems);
        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ImplicitToList_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            SomeTextStructType, LowerSomeTextStructType
        };

        var source = TestHelper.Initialize(sourceItems);
        List<StructType> result = source;

        result[0] = default;
        result.Remove(LowerSomeTextStructType);

        TestHelper.VerifyInnerState(2, sourceItems, source);
    }

    [Fact]
    public void ImplicitToImmutableArray_SourceIsDefault_ExpectEmptyImmutableArray()
    {
        ImmutableArray<RefType> actual = default(FlatArray<RefType>);
        var expected = ImmutableArray<RefType>.Empty;

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public void ImplicitToImmutableArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new int?[]
        {
            MinusFifteen, One, PlusFifteen
        };

        ImmutableArray<int?> actual = TestHelper.Initialize(sourceItems);
        Assert.Equal(sourceItems, actual);
    }
}