using System;
using System.Collections.Generic;
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
    public void Indexer_SourceIsDefault_ExpectArgumentOutOfRangeException(int index)
    {
        var source = default(FlatArray<StructType>.Builder);

        try
        {
            _ = source[index];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Assert.Equal("index", ex.ParamName);
            return;
        }

        Assert.Fail("An expected ArgumentOutOfRangeException was not thrown");
    }

    [Theory]
    [InlineData(0, 1, TabString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 3, AnotherString, AnotherString, null, SomeString)]
    [InlineData(3, 4, "Zero", "One", "Two", "Three")]
    public void Indexer_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        var actual = source[index];
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, AnotherString, SomeString)]
    [InlineData(5, 2, EmptyString, TabString)]
    [InlineData(-1, 3, LowerSomeString, null, SomeString)]
    public void Indexer_IndexIsOutOfRange_ExpectArgumentOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);
        
        try
        {
            _ = source[index];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Assert.Equal("index", ex.ParamName);
            return;
        }

        Assert.Fail("An expected ArgumentOutOfRangeException was not thrown");
    }
}