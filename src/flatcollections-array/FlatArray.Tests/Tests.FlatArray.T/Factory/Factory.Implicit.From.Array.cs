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
    public void ImplicitFromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { MinusOne, PlusFifteen, MinusFifteen };
        FlatArray<int> actual = sourceArray;

        sourceArray[0] += 1;
        var expectedItems = new[] { MinusOne, PlusFifteen, MinusFifteen };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}