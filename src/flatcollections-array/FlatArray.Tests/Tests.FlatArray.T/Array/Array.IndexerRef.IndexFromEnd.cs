using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(Zero)]
    [InlineData(One)]
    [InlineData(2)]
    [InlineData(PlusFifteen)]
    public void IndexerRef_IndexFromEnd_SourceIsDefault_ExpectIndexOutOfRangeException(int indexFromEnd)
    {
        var fromEnd = Index.FromEnd(indexFromEnd);

        var source = default(FlatArray<RefType>);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source.ItemRef(fromEnd);
    }

    [Theory]
    [InlineData(0, 1, 1, EmptyString)]
    [InlineData(0, 2, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(0, 3, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(0, 4, 4, null, "One", "Two", "Three")]
    [InlineData(1, 1, 2, AnotherString, SomeString, LowerSomeString)]
    [InlineData(2, 1, 3, SomeString, AnotherString, null, LowerSomeString)]
    [InlineData(3, 1, 4, null, "One", "Two", "Three")]
    public void IndexerRef_IndexFromEnd_IndexIsInRange_ExpectItemIsFromSourceItemsByIndex(
        int index, int indexFromEnd, int sourceLength, params string?[] sourceItems)
    {
        var fromEnd = Index.FromEnd(indexFromEnd);

        var source = sourceItems.InitializeFlatArray(sourceLength);

        var actual = source.ItemRef(fromEnd);
        var expected = sourceItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 1, SomeString)]
    [InlineData(0, 1, EmptyString, AnotherString)]
    [InlineData(4, 3, LowerSomeString, null, SomeString)]
    public void IndexerRef_IndexFromEnd_IndexIsOutOfRange_ExpectIndexOutOfRangeException(
        int indexFromEnd, int sourceLength, params string?[] sourceItems)
    {
        var fromEnd = Index.FromEnd(indexFromEnd);

        var source = sourceItems.InitializeFlatArray(sourceLength);
        var ex = Assert.Throws<IndexOutOfRangeException>(Test);

        void Test()
            =>
            _ = source.ItemRef(fromEnd);
    }
}