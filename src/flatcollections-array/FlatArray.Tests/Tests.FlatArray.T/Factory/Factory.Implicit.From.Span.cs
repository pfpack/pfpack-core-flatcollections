using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitFromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<bool?> actual = default(ReadOnlySpan<bool?>);
        actual.VerifyInnerState_Default();
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(Zero, MinusFifteen, One, int.MaxValue)]
    public void ImplicitFromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params int[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();
        FlatArray<int> actual = new ReadOnlySpan<int>(sourceItems);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ImplicitFromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<RefType> actual = default(Span<RefType>);
        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ImplicitFromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, ZeroIdRefType, null };
        FlatArray<RefType?> actual = new Span<RefType?>(sourceItems);

        actual.VerifyInnerState(sourceItems, sourceItems.Length);
    }

    [Fact]
    public void ImplicitFromSpan_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[] { 1, 71, -289, 55, 91 };
        var source = sourceItems.AsSpan();

        FlatArray<int> actual = source;
        source[0] += 5;

        var expectedItems = new[] { 1, 71, -289, 55, 91 };
        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}