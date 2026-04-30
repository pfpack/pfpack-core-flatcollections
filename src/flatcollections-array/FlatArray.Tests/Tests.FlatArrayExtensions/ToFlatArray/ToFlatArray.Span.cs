using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsEmptySpan_ExpectInnerStateIsDefault()
    {
        var source = default(Span<RecordType>);
        var actual = source.ToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptySpan_ExpectInnerStateAreSourceItems()
    {
        var source = new[] { SomeTextRecordStruct, AnotherTextRecordStruct }.AsSpan();

        var actual = source.ToFlatArray();
        var expectedItems = new[] { SomeTextRecordStruct, AnotherTextRecordStruct };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ToFlatArray_ThenModifySourceSpan_ExpectInnerStateHasNotChanged()
    {
        var source = new int?[] { MinusFifteen, Zero, One, null, MinusOne, PlusFifteen }.AsSpan();
        var actual = source.ToFlatArray();

        source[4] += 1;
        var expectedItems = new int?[] { MinusFifteen, Zero, One, null, MinusOne, PlusFifteen };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}