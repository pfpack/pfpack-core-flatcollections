using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<RecordType>);
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData("First", "Second", "Third")]
    public void FromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params string?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        var source = new ReadOnlySpan<string?>(sourceItems);
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(Span<StructType?>);
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        Span<int> source = stackalloc int[] { 5, 11, -17, 27, -81 };
        var actual = FlatArray<int>.From(source);

        const int expectedLength = 5;
        var expectedItems = new[] { 5, 11, -17, 27, -81 };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void FromSpan_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType
        };

        var source = sourceItems.AsSpan();
        var actual = FlatArray<RefType>.From(source);

        source[0] = MinusFifteenIdRefType;

        var expectedItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}