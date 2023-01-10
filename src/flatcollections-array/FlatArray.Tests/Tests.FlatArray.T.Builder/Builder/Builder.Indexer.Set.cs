using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void Indexer_Set_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var source = new FlatArray<StructType>.Builder();

        _ = Assert.Throws<IndexOutOfRangeException>(() => source[index] = new StructType() { Text = SomeString });
    }

    [Theory]
    [InlineData(0, 1, TabString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 3, AnotherString, AnotherString, null, SomeString)]
    [InlineData(3, 4, "Zero", "One", "Two", "Three")]
    public void Indexer_Set_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        const string newValue = "a_new_value";

        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        source[index] = newValue;

        var actual = source[index];
        var expected = newValue;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, AnotherString, SomeString)]
    [InlineData(5, 2, EmptyString, TabString)]
    [InlineData(-1, 3, LowerSomeString, null, SomeString)]
    public void Indexer_Set_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        _ = Assert.Throws<IndexOutOfRangeException>(() => source[index] = SomeString);
    }
}