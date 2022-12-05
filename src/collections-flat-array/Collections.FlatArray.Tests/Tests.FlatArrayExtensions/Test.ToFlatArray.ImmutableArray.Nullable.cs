using System.Collections.Immutable;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsNullImmutableArray_ExpectInnerStateIsDefault()
    {
        ImmutableArray<string?>? source = null;
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNullableDefaultImmutableArray_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RecordStruct>? source = new ImmutableArray<RecordStruct>();;
        var actual = source.ToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ToFlatArray_SourceIsNotNullableDefaultImmutableArray_ExpectInnerStateAreSourceItems()
    {
        ImmutableArray<int>? source = new[] { MinusFifteen, One, Zero, PlusFifteen }.ToImmutableArray();

        var actual = source.ToFlatArray();
        var expectedItems = new[] { MinusFifteen, One, Zero, PlusFifteen };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}