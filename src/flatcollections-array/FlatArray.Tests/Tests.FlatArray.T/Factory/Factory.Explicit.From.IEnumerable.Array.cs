using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromIEnumerable_Array_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        IEnumerable<StructType> source = Array.Empty<StructType>();
        var actual = FlatArray<StructType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen, null, MinusFifteen, PlusFifteen)]
    [InlineData(12, 15, 1, 91, 7, -95, null, 0, 5, 6, 7, 901, 98, -266, 78, 62, 21, 35, 75, 212, 51)]
    public void FromIEnumerable_Array_SourceIsNotEmpty_ExpectInnerStateIsSourceArray(
        params int?[] source)
    {
        var copied = source.GetCopy();
        var actual = FlatArray<int?>.From((IEnumerable<int?>)source);

        actual.VerifyInnerState(copied, copied.Length);
    }

    [Fact]
    public void FromIEnumerable_Array_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { "One", "Two", "Three" };
        var actual = FlatArray<string>.From((IEnumerable<string>)sourceArray);

        sourceArray[1] = "2";
        var expectedItems = new[] { "One", "Two", "Three" };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}