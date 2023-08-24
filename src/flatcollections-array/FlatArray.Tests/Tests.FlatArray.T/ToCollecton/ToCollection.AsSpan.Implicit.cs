using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void AsSpanImplicit_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RefType?>);

        ReadOnlySpan<RefType?> actual = source;
        var expected = default(ReadOnlySpan<RefType?>);

        Assert.True(expected == actual);
    }

    [Fact]
    public void AsSpanImplicit_SourceIsNotDefault_ExpectSourceItems()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, AnotherTextRecordStruct
        };

        var source = sourceItems.InitializeFlatArray();

        ReadOnlySpan<RecordStruct> actual = source;
        var expected = sourceItems.AsSpan();

        Assert.True(expected == actual);
    }

    [Fact]
    public void AsSpanImplicit_InnerLengthIsLessThanItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            MinusFifteen, PlusFifteen, One
        };

        const int innerLength = 2;
        var source = sourceItems.InitializeFlatArray(innerLength);

        ReadOnlySpan<int> actual = source;
        var expected = new ReadOnlySpan<int>(sourceItems, 0, innerLength);

        Assert.True(expected == actual);
    }
}