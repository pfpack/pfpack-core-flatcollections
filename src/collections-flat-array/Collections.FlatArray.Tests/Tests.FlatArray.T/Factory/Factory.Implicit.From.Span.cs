using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitFromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<bool?> actual = default(ReadOnlySpan<bool?>);
        actual.VerifyDefaultState();
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(Zero, MinusFifteen, One, int.MaxValue)]
    public void ImplicitFromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params int[] sourceItems)
    {
        FlatArray<int> actual = new ReadOnlySpan<int>(sourceItems);
        actual.VerifyInnerState(sourceItems.Length, sourceItems);
    }

    [Fact]
    public void ImplicitFromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<RefType> actual = default(Span<RefType>);
        actual.VerifyDefaultState();
    }

    [Fact]
    public void ImplicitFromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, ZeroIdRefType, null };
        FlatArray<RefType?> actual = new Span<RefType?>(sourceItems);

        actual.VerifyInnerState(sourceItems.Length, sourceItems);
    }

    [Fact]
    public void ImplicitFromSpan_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[] { 1, 71, -289, 55, 91 };
        var source = sourceItems.AsSpan();

        FlatArray<int> actual = source;
        source[0] += 5;

        var expectedItems = new[] { 1, 71, -289, 55, 91 };
        actual.VerifyInnerState(expectedItems.Length, expectedItems);
    }
}