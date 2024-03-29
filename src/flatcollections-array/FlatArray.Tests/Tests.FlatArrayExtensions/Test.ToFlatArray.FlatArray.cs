using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsDefaultFlatArray_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType>);
        var actual = source.ToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotDefaultFlatArray_ExpectInnerStateIsSourceArray()
    {
        var source = new FlatArray<RecordType?>(MinusFifteenIdNullNameRecord, null, ZeroIdNullNameRecord);

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteenIdNullNameRecord, null, ZeroIdNullNameRecord };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}