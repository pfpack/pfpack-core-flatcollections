using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

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

    [Fact]
    public void AsMemory_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            SomeString, null, EmptyString, AnotherString, WhiteSpaceString
        };

        const int innerLength = 3;
        var source = sourceItems.InitializeFlatArray(innerLength);

        var actual = source.AsMemory();
        var expected = new Memory<string?>(sourceItems, 0, innerLength);

        Assert.StrictEqual(expected, actual);
    }
}