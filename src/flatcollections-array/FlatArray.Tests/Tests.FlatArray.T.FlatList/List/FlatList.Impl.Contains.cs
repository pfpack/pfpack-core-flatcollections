using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Contains_SourceIsEmpty_ExpectFalse()
    {
        var source = TestHelper.CreateEmptyFlatList<RefType?>();
        var actual = source.Contains(MinusFifteenIdRefType);

        Assert.False(actual);
    }

    [Theory]
    [InlineData(SomeString, 1, SomeString)]
    [InlineData(null, 2, TabString, null, EmptyString)]
    [InlineData(SomeString, 3, LowerSomeString, AnotherString, SomeString, EmptyString)]
    [InlineData(AnotherString, 5, SomeString, AnotherString, null, EmptyString, TabString)]
    public void Contains_SourceItemContainsItem_ExpectTrue(
        string? item, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);
        var actual = source.Contains(item);

        Assert.True(actual);
    }

    [Theory]
    [InlineData(TabString, 1, EmptyString)]
    [InlineData(SomeString, 1, TabString, SomeString)]
    [InlineData(null, 3, SomeString, AnotherString, EmptyString)]
    public void Contains_SourceItemsDoesNotContainItem_ExpectFalse(
        string? item, int sourceLength, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatList(sourceLength);
        var actual = source.Contains(item);

        Assert.False(actual);
    }
}