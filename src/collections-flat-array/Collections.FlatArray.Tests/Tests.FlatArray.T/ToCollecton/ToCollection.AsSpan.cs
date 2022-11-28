using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void AsSpan_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RefType?>);

        var actual = source.AsSpan();
        var expected = default(ReadOnlySpan<RefType?>);

        Assert.True(expected == actual);
    }

    [Fact]
    public void AsSpan_SourceIsNotDefault_ExpectSourceItems()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatArray();

        var actual = source.AsSpan();
        var expected = sourceItems.AsSpan();

        Assert.True(expected == actual);
    }
}