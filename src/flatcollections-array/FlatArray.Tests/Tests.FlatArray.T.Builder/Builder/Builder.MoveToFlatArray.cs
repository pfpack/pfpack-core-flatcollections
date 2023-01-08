using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectArrayStateIsDefault()
    {
        var source = new FlatArray<string>.Builder();
        var actual = source.MoveToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectBuilderStateIsDefault()
    {
        var source = new FlatArray<RefType>.Builder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState(default, default);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectArrayItemsAreBuilderItems()
    {
        const int length = 3;

        var sourceItems = new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType };
        var source = sourceItems.InitializeFlatArrayBuilder(length);

        var actual = source.MoveToFlatArray();
        var expectedItems = new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType };

        actual.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectBuilderStateIsDefault()
    {
        var source = new[] { MinusFifteen, Zero, PlusFifteen, int.MaxValue, One }.InitializeFlatArrayBuilder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState(default, default);
    }
}