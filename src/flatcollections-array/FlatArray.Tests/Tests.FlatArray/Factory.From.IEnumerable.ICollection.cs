using System;
using System.Collections.Generic;
using System.Diagnostics;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromIEnumerable_ICollection_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = new StubCollection<StructType?>(new());
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromIEnumerable_ICollection_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new List<RefType?>
        {
            PlusFifteenIdRefType, ZeroIdRefType, null
        };

        var source = new StubCollection<RefType?>(sourceItems);
        var actual = FlatArray<RefType?>.From(source);

        var expectedItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType, null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromIEnumerable_ICollection_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<StructType>
        {
            SomeTextStructType, default
        };

        var source = new StubCollection<StructType>(sourceList);
        var actual = FlatArray<StructType>.From(source);

        var wasRemoved = source.Remove(SomeTextStructType);
        Debug.Assert(wasRemoved);

        var expectedItems = new[]
        {
            SomeTextStructType, default
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}