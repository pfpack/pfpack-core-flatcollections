using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Remove_SourceIsEmpty_ExpectNotSupportedException()
    {
        var source = TestHelper.CreateEmptyFlatList<RecordType?>();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            _ = source.Remove(MinusFifteenIdNullNameRecord);
    }

    [Fact]
    public void Remove_SourceIsNotEmpty_ExpectNotSupportedException()
    {
        var source = new[] { SomeTextStructType }.InitializeFlatList();
        _ = Assert.Throws<NotSupportedException>(Test);

        void Test()
            =>
            _ = source.Remove(SomeTextStructType);
    }
}