using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ConstructFromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<bool?> actual = new(default(ReadOnlySpan<bool?>));
        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(Zero, MinusFifteen, One, int.MaxValue)]
    public void ConstructFromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params int[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();
        FlatArray<int> actual = new(new ReadOnlySpan<int>(sourceItems));

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<RefType> actual = new(default(Span<RefType>));
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, ZeroIdRefType, null };
        FlatArray<RefType?> actual = new(new Span<RefType?>(sourceItems));

        actual.VerifyInnerState(sourceItems, sourceItems.Length);
    }

    [Fact]
    public void ConstructFromSpan_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[] { 1, 71, -289, 55, 91 };
        var source = sourceItems.AsSpan();

        FlatArray<int> actual = new(source);
        source[0] += 5;

        var expectedItems = new[] { 1, 71, -289, 55, 91 };
        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}