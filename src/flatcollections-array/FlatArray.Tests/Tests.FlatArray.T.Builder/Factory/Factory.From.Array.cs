using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        StructType[]? source = null;
        var actual = FlatArray<StructType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType>(), default);
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RecordType>();
        var actual = FlatArray<RecordType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, Zero, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, 975, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int[] source)
    {
        var coppied = source.GetCopy();
        var actual = FlatArray<int>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray<string>.Builder.From(sourceArray);

        sourceArray[0] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}