using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void ConstructFromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        RecordType[]? source = null;
        var actual = new FlatArray<RecordType>.Builder(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RecordStruct?>();
        var actual = new FlatArray<RecordStruct?>.Builder(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(AnotherString)]
    [InlineData(SomeString, LowerAnotherString, EmptyString, null, UpperSomeString)]
    [InlineData("01", "02", "03", "04", "05", "06", "07", null, "09", "10", "11", "12", "13", "14", TabString, "16", "17")]
    public void ConstructFromArray_SourceIsNotEmpty_ExpectInnerStateIsSource(
        params string?[] source)
    {
        var coppied = source.GetCopy();
        var actual = new FlatArray<string?>.Builder(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromArray_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { PlusFifteenIdRefType, ZeroIdRefType };
        var actual = new FlatArray<RefType>.Builder(sourceArray);

        sourceArray[0] = MinusFifteenIdRefType;
        var expectedItems = new[] { PlusFifteenIdRefType, ZeroIdRefType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}