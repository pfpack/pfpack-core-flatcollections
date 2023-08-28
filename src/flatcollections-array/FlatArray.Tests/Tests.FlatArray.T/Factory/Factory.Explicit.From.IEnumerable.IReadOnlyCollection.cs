using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromIEnumerable_IReadOnlyCollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var sourceItems = Array.Empty<string?>();
        var source = new StubReadOnlyCollection<string?>(sourceItems);

        var actual = FlatArray<string?>.From(source);
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromIEnumerable_IReadOnlyCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            null, PlusFifteenIdRefType, ZeroIdRefType
        };

        var source = new StubReadOnlyCollection<RefType?>(sourceItems);
        var actual = FlatArray<RefType?>.From(source);

        var expectedItems = new[]
        {
            null, PlusFifteenIdRefType, ZeroIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}