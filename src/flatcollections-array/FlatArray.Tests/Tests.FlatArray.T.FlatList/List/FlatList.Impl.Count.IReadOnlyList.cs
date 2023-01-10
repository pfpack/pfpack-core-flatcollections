using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Count_IReadOnlyList_SourceIsEmpty_ExpectDefault()
    {
        var source = TestHelper.CreateEmptyFlatListAsReadOnly<StructType>();

        var actual = source.Count;
        const int expected = default;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(2, null, SomeString, TabString)]
    [InlineData(3, null, EmptyString, AnotherString)]
    public void Count_IReadOnlyList_SourceIsNotEmpty_ExpectInnerLength(
        int innerLength, params string?[] innerItems)
    {
        var source = innerItems.InitializeFlatListAsReadOnly(innerLength);

        var actual = source.Count;
        var expected = innerLength;

        Assert.Equal(expected, actual);
    }
}