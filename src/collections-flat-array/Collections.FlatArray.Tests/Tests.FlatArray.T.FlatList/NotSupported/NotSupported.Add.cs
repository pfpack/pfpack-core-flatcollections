using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Add_SourceIsEmpty_ExpectNotSupportedException()
    {
        var source = TestHelper.CreateEmptyFlatList<RecordStruct?>();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.Add(SomeTextRecordStruct);
    }

    [Fact]
    public void Add_SourceIsNotEmpty_ExpectNotSupportedException()
    {
        var source = new[] { MinusFifteenIdRefType }.InitializeFlatList();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            source.Add(ZeroIdRefType);
    }
}