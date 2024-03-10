using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        object?[]? source = null;
        var actual = FlatArray<object?>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<StructType>();
        var actual = FlatArray<StructType>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, null, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, null, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromArray_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int?[] source)
    {
        var copied = source.GetCopy();
        var actual = FlatArray<int?>.From(source);

        actual.VerifyInnerState(copied, copied.Length);
    }

    [Fact]
    public void FromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray<string>.From(sourceArray);

        sourceArray[1] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}