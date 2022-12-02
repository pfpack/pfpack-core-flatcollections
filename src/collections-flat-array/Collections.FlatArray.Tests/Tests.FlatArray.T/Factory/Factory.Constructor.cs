using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ConstructFromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        int[]? source = null;
        var actual = new FlatArray<int>(source);

        TestHelper.VerifyDefaultState(actual);
    }

    [Fact]
    public void ConstructFromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType>();
        var actual = new FlatArray<RefType>(source);

        TestHelper.VerifyDefaultState(actual);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(null, LowerAnotherString, EmptyString, WhiteSpaceString, UpperSomeString)]
    [InlineData("01", "02", "03", null, "05", "06", "07", "08", "09", "10", EmptyString, "12", "13", "14", "15", "16", "17")]
    public void ConstructFromArray_SourceIsNotEmpty_ExpectInnerStateIsSource(
        params string?[] source)
    {
        var actual = new FlatArray<string?>(source);
        TestHelper.VerifyInnerState(source.Length, source, actual);
    }

    [Fact]
    public void ConstructFromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { MinusFifteen, Zero, int.MaxValue };
        var actual = new FlatArray<int>(sourceArray);

        sourceArray[0] = PlusFifteen;
        var expectedItems = new[] { MinusFifteen, Zero, int.MaxValue };

        TestHelper.VerifyInnerState(expectedItems.Length, expectedItems, actual);
    }
}