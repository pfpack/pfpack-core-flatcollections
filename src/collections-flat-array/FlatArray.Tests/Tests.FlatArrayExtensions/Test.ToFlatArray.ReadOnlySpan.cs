using System;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsEmptyReadOnlySpan_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<long?>);
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyReadOnlySpan_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, null, ZeroIdRefType, PlusFifteenIdRefType };
        var source = new ReadOnlySpan<RefType?>(sourceItems);

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteenIdRefType, null, ZeroIdRefType, PlusFifteenIdRefType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}