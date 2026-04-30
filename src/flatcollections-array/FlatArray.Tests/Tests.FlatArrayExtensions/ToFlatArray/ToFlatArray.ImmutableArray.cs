using System;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsDefaultImmutableArray_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<RecordType>);
        var actual = source.ToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotDefaultImmutableArray_ExpectInnerStateAreSourceItems()
    {
        var source = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType }.ToImmutableArray();

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}