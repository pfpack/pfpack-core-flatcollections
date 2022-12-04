using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void MoveToArray_SourceIsDefault_ExpectArrayStateIsDefault()
    {
        var source = default(FlatArray<string>.Builder);
        var actual = source.MoveToArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void MoveToArray_SourceIsDefault_ExpectBuilderStateIsDefault()
    {
        var source = default(FlatArray<RefType>.Builder);
        _ = source.MoveToArray();

        source.VerifyInnerState(default, default);
    }

    [Fact]
    public void MoveToArray_SourceIsNotDefault_ExpectArrayItemsAreBuilderItems()
    {
        const int length = 3;

        var sourceItems = new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType };
        var source = sourceItems.InitializeFlatArrayBuilder(length);

        var actual = source.MoveToArray();
        var expectedItems = new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType };

        actual.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void MoveToArray_SourceIsNotDefault_ExpectBuilderStateIsDefault()
    {
        var source = new[] { MinusFifteen, Zero, PlusFifteen, int.MaxValue, One }.InitializeFlatArrayBuilder();
        _ = source.MoveToArray();

        source.VerifyInnerState(default, default);
    }
}