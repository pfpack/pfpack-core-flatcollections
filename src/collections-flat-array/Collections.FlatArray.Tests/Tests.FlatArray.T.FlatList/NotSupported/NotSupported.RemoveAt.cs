using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void RemoveAt_SourceIsEmpty_ExpectNotSupportedException(int index)
    {
        var source = TestHelper.CreateEmptyFlatList<DateOnly?>();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.RemoveAt(index);
    }

    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void RemoveAt_SourceIsNotEmpty_ExpectNotSupportedException(int index)
    {
        var source = new[] { SomeString, EmptyString, AnotherString }.InitializeFlatList();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.RemoveAt(index);
    }
}