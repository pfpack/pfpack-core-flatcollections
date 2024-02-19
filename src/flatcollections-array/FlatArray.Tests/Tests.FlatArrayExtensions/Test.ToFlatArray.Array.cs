using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsNullArray_ExpectInnerStateIsDefault()
    {
        RecordStruct[]? source = null;
        var actual = source.ToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ToFlatArray_SourceIsEmptyArray_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType>();
        var actual = source.ToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyArray_ExpectInnerStateIsSourceArray()
    {
        var source = new[] { MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord };

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ToFlatArray_ThenModifySourceArray_ExpectInnerStateHasNotChanged()
    {
        var source = new[] { default, SomeTextStructType };
        var actual = source.ToFlatArray();

        source[0] = LowerSomeTextStructType;
        var expectedItems = new[] { default, SomeTextStructType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}