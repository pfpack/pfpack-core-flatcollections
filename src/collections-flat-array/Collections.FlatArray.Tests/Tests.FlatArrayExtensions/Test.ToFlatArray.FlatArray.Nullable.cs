using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsNullFlatArray_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RecordType?>?);
        var actual = source.ToFlatArray();

        actual.VerifyDefaultState();
    }

    [Fact]
    public void ToFlatArray_SourceIsNullableDefaultFlatArray_ExpectInnerStateIsDefault()
    {
        FlatArray<StructType>? source = default(FlatArray<StructType>);
        var actual = source.ToFlatArray();

        actual.VerifyDefaultState();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotNullableDefaultFlatArray_ExpectInnerStateIsSourceArray()
    {
        FlatArray<RefType>? source = new[] { MinusFifteenIdRefType, PlusFifteenIdRefType }.InitializeFlatArray();

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteenIdRefType, PlusFifteenIdRefType };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}