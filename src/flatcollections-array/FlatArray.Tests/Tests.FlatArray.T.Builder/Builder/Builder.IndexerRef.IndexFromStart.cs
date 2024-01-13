using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(PlusFifteen)]
    public void IndexerRef_IndexFromStart_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var fromStart = Index.FromStart(index);

        var source = new FlatArray<StructType>.Builder();

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source.ItemRef(fromStart));
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
    public void IndexerRef_IndexFromStart_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var fromStart = Index.FromStart(index);

        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        var actual = source.ItemRef(fromStart);
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, AnotherString, SomeString)]
    [InlineData(5, 2, EmptyString, TabString)]
    public void IndexerRef_IndexFromStart_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var fromStart = Index.FromStart(index);

        var source = sourceItems.InitializeFlatArrayBuilder(sourceLength);

        _ = Assert.Throws<IndexOutOfRangeException>(() => _ = source.ItemRef(fromStart));
    }
}