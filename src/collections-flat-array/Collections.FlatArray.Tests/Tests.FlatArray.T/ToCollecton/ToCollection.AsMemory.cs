using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void AsMemory_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<StructType>);

        var actual = source.AsMemory();
        var expected = default(ReadOnlyMemory<StructType>);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public void AsMemory_SourceIsNotDefault_ExpectSourceItems()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType, null, MinusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray();

        var actual = source.AsMemory();
        var expected = sourceItems.AsMemory();

        Assert.StrictEqual(expected, actual);
    }
}