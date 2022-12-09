using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void IndexOf_SourceIsEmpty_ExpectMinusOne()
    {
        var source = TestHelper.CreateEmptyFlatList<StructType>();

        var actual = source.IndexOf(SomeTextStructType);
        const int expected = -1;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(EmptyString, 0, 1, EmptyString)]
    [InlineData(SomeString, 1, 2, LowerSomeString, SomeString, AnotherString)]
    [InlineData(null, 2, 3, EmptyString, SomeString, null, AnotherString)]
    [InlineData(TabString, 3, 7, AnotherString, SomeString, EmptyString, TabString, SomeString, TabString, WhiteSpaceString)]
    public void IndexOf_SourceArrayContainsItem_ExpectItemIndex(
        string? item, int expected, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);
        var actual = source.IndexOf(item);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, 1, false)]
    [InlineData(false, 1, null, true)]
    [InlineData(null, 3, true, false, false)]
    [InlineData(true, 2, false, false, true)]
    public void IndexOf_SourceArrayDoesNotContainItem_ExpectMinusOne(
        bool? item, int sourceLength, params bool?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);

        var actual = source.IndexOf(item);
        const int expected = -1;

        Assert.Equal(expected, actual);
    }
}