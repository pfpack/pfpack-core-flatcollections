using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    public void IndexerRef_IndexFromStart_SourceIsDefault_ExpectIndexOutOfRangeException(int index)
    {
        var fromStart = Index.FromStart(index);

        var source = default(FlatArray<RefType>);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source.ItemRef(fromStart);
    }

    [Theory]
    [InlineData(0, 1, EmptyString)]
    [InlineData(1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(3, 4, null, "One", "Two", "Three")]
    public void IndexerRef_IndexFromStart_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var fromStart = Index.FromStart(index);

        var source = sourceItems.InitializeFlatArray(sourceLength);

        var actual = source.ItemRef(fromStart);
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, SomeString)]
    [InlineData(1, 1, EmptyString, AnotherString)]
    [InlineData(5, 2, EmptyString, SomeString)]
    public void IndexerRef_IndexFromStart_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int index, int sourceLength, params string?[] sourceItems)
    {
        var fromStart = Index.FromStart(index);

        var source = sourceItems.InitializeFlatArray(sourceLength);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source.ItemRef(fromStart);
    }
}