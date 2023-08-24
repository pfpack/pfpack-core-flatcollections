using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void AsMemoryImplicit_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<StructType>);

        ReadOnlyMemory<StructType> actual = source;
        var expected = default(ReadOnlyMemory<StructType>);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public void AsMemoryImplicit_SourceIsNotDefault_ExpectSourceItems()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType, null, MinusFifteenIdRefType
        };

        var source = sourceItems.InitializeFlatArray();

        ReadOnlyMemory<RefType?> actual = source;
        var expected = sourceItems.AsMemory();

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public void AsMemoryImplicit_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            SomeString, null, EmptyString, AnotherString, WhiteSpaceString
        };

        const int innerLength = 3;
        var source = sourceItems.InitializeFlatArray(innerLength);

        ReadOnlyMemory<string?> actual = source;
        var expected = new Memory<string?>(sourceItems, 0, innerLength);

        Assert.StrictEqual(expected, actual);
    }
}