using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Clear_SourceIsEmpty_ExpectNotSupportedException()
    {
        var source = TestHelper.CreateEmptyFlatList<RefType>();
        _ = Assert.Throws<NotSupportedException>(source.Clear);
    }

    [Fact]
    public void Clear_SourceIsNotEmpty_ExpectNotSupportedException()
    {
        var source = new int?[] { PlusFifteen, null, MinusOne }.InitializeFlatList();
        _ = Assert.Throws<NotSupportedException>(source.Clear);
    }
}