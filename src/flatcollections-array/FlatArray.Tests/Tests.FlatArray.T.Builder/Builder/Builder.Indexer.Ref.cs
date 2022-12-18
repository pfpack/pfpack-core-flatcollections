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
    public void IndexerRef_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var source = new FlatArray<StructType>.Builder();

        try
        {
            _ = source.ItemRef(index);
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        Assert.Fail("An expected IndexOutOfRangeException was not thrown");
    }

    [Theory]
    [InlineData(0, 1, TabString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 3, AnotherString, AnotherString, null, SomeString)]
    [InlineData(3, 4, "Zero", "One", "Two", "Three")]
    public void IndexerRef_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        var actual = source.ItemRef(index);
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, AnotherString, SomeString)]
    [InlineData(5, 2, EmptyString, TabString)]
    [InlineData(-1, 3, LowerSomeString, null, SomeString)]
    public void IndexerRef_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);
        
        try
        {
            _ = source.ItemRef(index);
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        Assert.Fail("An expected IndexOutOfRangeException was not thrown");
    }
}