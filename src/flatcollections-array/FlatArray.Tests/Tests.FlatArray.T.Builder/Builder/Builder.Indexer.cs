using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MinValue + 1)]
    [InlineData(MinusFifteen)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(PlusFifteen)]
    [InlineData(int.MaxValue - 1)]
    [InlineData(int.MaxValue)]
    public void Indexer_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var source = new FlatArray<StructType>.Builder();

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source[index]);
    }

    [Theory]
    [InlineData(0, 1, EmptyString)]
    [InlineData(0, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(0, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(1, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(2, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(0, 4, null, "One", "Two", "Three")]
    [InlineData(1, 4, null, "One", "Two", "Three")]
    [InlineData(2, 4, null, "One", "Two", "Three")]
    [InlineData(3, 4, null, "One", "Two", "Three")]
    public void Indexer_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        var actual = source[index];
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    // Effective Length: 1, Inner array length: 1
    [InlineData(int.MinValue, 1, SomeString)]
    [InlineData(int.MinValue + 1, 1, SomeString)]
    [InlineData(MinusFifteen, 1, SomeString)]
    [InlineData(-1, 1, SomeString)]
    [InlineData(1, 1, SomeString)]
    [InlineData(PlusFifteen, 1, SomeString)]
    [InlineData(int.MaxValue - 1, 1, SomeString)]
    [InlineData(int.MaxValue, 1, SomeString)]
    // Effective Length: 1, Inner array length: 2
    [InlineData(int.MinValue, 1, EmptyString, AnotherString)]
    [InlineData(int.MinValue + 1, 1, EmptyString, AnotherString)]
    [InlineData(MinusFifteen, 1, EmptyString, AnotherString)]
    [InlineData(-1, 1, EmptyString, AnotherString)]
    [InlineData(1, 1, EmptyString, AnotherString)]
    [InlineData(PlusFifteen, 1, EmptyString, AnotherString)]
    [InlineData(int.MaxValue - 1, 1, EmptyString, AnotherString)]
    [InlineData(int.MaxValue, 1, EmptyString, AnotherString)]
    // Effective Length: 2, Inner array length: 2
    [InlineData(int.MinValue, 2, EmptyString, SomeString)]
    [InlineData(int.MinValue + 1, 2, EmptyString, SomeString)]
    [InlineData(MinusFifteen, 2, EmptyString, SomeString)]
    [InlineData(-1, 2, EmptyString, SomeString)]
    [InlineData(2, 2, EmptyString, SomeString)]
    [InlineData(PlusFifteen, 2, EmptyString, SomeString)]
    [InlineData(int.MaxValue - 1, 2, EmptyString, SomeString)]
    [InlineData(int.MaxValue, 2, EmptyString, SomeString)]
    // Effective Length: 3, Inner array length: 3
    [InlineData(int.MinValue, 3, LowerSomeString, null, SomeString)]
    [InlineData(int.MinValue + 1, 3, LowerSomeString, null, SomeString)]
    [InlineData(MinusFifteen, 3, LowerSomeString, null, SomeString)]
    [InlineData(-1, 3, LowerSomeString, null, SomeString)]
    [InlineData(3, 3, LowerSomeString, null, SomeString)]
    [InlineData(PlusFifteen, 3, LowerSomeString, null, SomeString)]
    [InlineData(int.MaxValue - 1, 3, LowerSomeString, null, SomeString)]
    [InlineData(int.MaxValue, 3, LowerSomeString, null, SomeString)]
    public void Indexer_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source[index]);
    }
}