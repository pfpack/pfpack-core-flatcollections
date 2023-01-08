using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void Enumerator_Current_SourceIsDefault_ExpectIndexOutOfRangeException()
    {
        var source = default(FlatArray<RefType>.Builder.Enumerator);

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source.Current);
    }

    [Theory]
    [InlineData(0, 1, SomeString)]
    [InlineData(1, 2, EmptyString, SomeString, AnotherString)]
    public void Enumerator_Current_IndexIsInRange_ExpectItemByIndex(
        int index, int length, params string[] sourceItems)
    {
        var coppiedItems = sourceItems.GetCopy();
        var source = sourceItems.InitializeFlatArrayBuilder(length).InitializeEnumerator(index);

        var actual = source.Current;
        var expected = coppiedItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, PlusFifteen)]
    [InlineData(3, 2, MinusFifteen, null, Zero, One, PlusFifteen)]
    [InlineData(-1, 2, MinusOne, PlusFifteen)]
    public void Enumerator_Current_IndexIsNotInRange_ExpectIndexOutOfRangeException(
        int index, int length, params int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(length).InitializeEnumerator(index);

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source.Current);
    }
}