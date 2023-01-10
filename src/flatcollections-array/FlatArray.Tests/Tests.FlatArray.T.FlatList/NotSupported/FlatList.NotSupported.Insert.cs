using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void Insert_SourceIsEmpty_ExpectNotSupportedException(int index)
    {
        var source = TestHelper.CreateEmptyFlatList<string>();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.Insert(index, AnotherString);
    }

    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void Insert_SourceIsNotEmpty_ExpectNotSupportedException(int index)
    {
        var source = new[] { decimal.One, decimal.MaxValue }.InitializeFlatList();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.Insert(index, decimal.Zero);
    }
}