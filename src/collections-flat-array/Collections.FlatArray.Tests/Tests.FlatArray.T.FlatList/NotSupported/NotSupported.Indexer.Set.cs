using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void IndexerSet_SourceIsEmpty_ExpectNotSupportedException(int index)
    {
        var source = TestHelper.CreateEmptyFlatList<RecordStruct?>();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source[index] = SomeTextRecordStruct;
    }

    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(One)]
    public void IndexerSet_SourceIsNotEmpty_ExpectNotSupportedException(int index)
    {
        var source = new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType }.InitializeFlatList(2);
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source[index] = ZeroIdRefType;
    }
}