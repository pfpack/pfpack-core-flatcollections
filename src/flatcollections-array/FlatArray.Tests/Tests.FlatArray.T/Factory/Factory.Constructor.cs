using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ConstructFromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        int[]? source = null;
        var actual = new FlatArray<int>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType>();
        var actual = new FlatArray<RefType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(null, LowerAnotherString, EmptyString, WhiteSpaceString, UpperSomeString)]
    [InlineData("01", "02", "03", null, "05", "06", "07", "08", "09", "10", EmptyString, "12", "13", "14", "15", "16", "17")]
    public void ConstructFromArray_SourceIsNotEmpty_ExpectInnerStateIsSource(
        params string?[] source)
    {
        var coppied = source.GetCopy();
        var actual = new FlatArray<string?>(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromArray_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { MinusFifteen, Zero, int.MaxValue };
        var actual = new FlatArray<int>(sourceArray);

        sourceArray[0] = PlusFifteen;
        var expectedItems = new[] { MinusFifteen, Zero, int.MaxValue };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}