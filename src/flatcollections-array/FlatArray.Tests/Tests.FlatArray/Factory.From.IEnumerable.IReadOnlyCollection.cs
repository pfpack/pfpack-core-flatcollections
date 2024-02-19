using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromIEnumerable_IReadOnlyCollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var sourceItems = new List<string?>();
        var source = new StubReadOnlyCollection<string?>(sourceItems);

        var actual = FlatArray<string?>.From(source);
        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromIEnumerable_IReadOnlyCollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RefType?>
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