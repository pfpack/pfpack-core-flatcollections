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
    public void ImplicitFromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        StructType[]? source = null;
        FlatArray<StructType> actual = source;

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType> actual = Array.Empty<RecordType>();
        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(null, SomeString, AnotherString, LowerSomeString)]
    public void ImplicitFromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params string?[] source)
    {
        var coppied = source.GetCopy();
        FlatArray<string?> actual = source;

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ImplicitFromArray_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { MinusOne, PlusFifteen, MinusFifteen };
        FlatArray<int> actual = sourceArray;

        sourceArray[0] += 1;
        var expectedItems = new[] { MinusOne, PlusFifteen, MinusFifteen };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ImplicitFromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<RefType>? source = null;
        FlatArray<RefType> actual = source;

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<long> actual = new List<long>();
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromList_SourceIsNotEmpty_ExpectInnerStateIsSourceArray()
    {
        var source = new List<string>
        {
            SomeString, EmptyString
        };

        FlatArray<string> actual = source;

        var expectedItems = new[]
        {
            SomeString, EmptyString
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ImplicitFromList_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<byte?>
        {
            0, 75, byte.MaxValue, 121, 235, null
        };

        FlatArray<byte?> actual = sourceList;

        sourceList[3] = 21;
        sourceList.Add(97);

        var expectedItems = new byte?[]
        {
            0, 75, byte.MaxValue, 121, 235, null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ImplicitFromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<RefType>);
        FlatArray<RefType> actual = source;

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems()
    {
        var sourceBuilder = ImmutableArray.CreateBuilder<string?>(5);

        sourceBuilder.Add("One");
        sourceBuilder.Add("Two");
        sourceBuilder.Add("Three");
        sourceBuilder.Add("Four");
        sourceBuilder.Add(null);

        FlatArray<string?> actual = sourceBuilder.ToImmutable();

        var expectedItems = new[]
        {
            "One", "Two", "Three", "Four", null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}