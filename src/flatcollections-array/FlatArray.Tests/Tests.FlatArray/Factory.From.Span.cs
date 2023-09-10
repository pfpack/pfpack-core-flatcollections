using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<StructType?>);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(null, false, true)]
    public void FromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params bool?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = new ReadOnlySpan<bool?>(sourceItems);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(Span<RefType>);
        var actual = FlatArray.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        Span<byte?> source = stackalloc byte?[] { 115, 0, byte.MaxValue, 215 };
        var actual = FlatArray.From(source);

        const int expectedLength = 4;
        var expectedItems = new byte?[] { 115, 0, byte.MaxValue, 215 };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromSpan_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, PlusFifteenIdLowerSomeStringNameRecord
        };

        var source = sourceItems.AsSpan();
        var actual = FlatArray.From(source);

        source[1] = PlusFifteenIdSomeStringNameRecord;

        var expectedItems = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, PlusFifteenIdLowerSomeStringNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}