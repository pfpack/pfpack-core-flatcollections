using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Enumerator_MoveNext_SourceIsDefault_ExpectFalseAndDefaultState()
    {
        var source = default(FlatArray<RefType>.Enumerator);
        var actual = source.MoveNext();

        Assert.False(actual);
        source.VerifyInnerState(0, null, 0);
    }

    [Theory]
    [InlineData(-1, MinusFifteen)]
    [InlineData(0, null, PlusFifteen, Zero)]
    [InlineData(2, MinusOne, PlusFifteen, MinusFifteen, Zero)]
    public void Enumerator_MoveNext_IndexIsLessThanLengthMinusOne_ExpectTrueAndNextIndex(
        int index, params int?[] items)
    {
        var copiedItems = items.GetCopy();

        var source = items.InitializeFlatArrayEnumerator(items.Length, index);
        var actual = source.MoveNext();

        Assert.True(actual);
        source.VerifyInnerState(copiedItems.Length, copiedItems, index + 1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1, SomeString)]
    [InlineData(3, AnotherString, EmptyString)]
    public void Enumerator_MoveNext_IndexIsEqualToLengthOrGreate_ExpectFalseAndIndexHasNotChanged(
        int index, params string?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatArrayEnumerator(items.Length, index);
        var actual = source.MoveNext();

        Assert.False(actual);
        source.VerifyInnerState(copied.Length, copied, index);
    }
}