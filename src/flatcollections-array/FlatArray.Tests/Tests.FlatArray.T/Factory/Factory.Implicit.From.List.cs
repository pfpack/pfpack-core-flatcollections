using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitFromList_SourceIsNull_ExpectInnerStateIsDefault()
    {
        List<RefType>? source = null;
        FlatArray<RefType> actual = source;

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromList_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        FlatArray<long> actual = new List<long>();
        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ImplicitFromList_SourceIsNotEmpty_ExpectInnerStateIsSourceArray()
    {
        var source = new List<string>
        {
            SomeString, EmptyString
        };

        FlatArray<string> actual = source;

        var expectedItems = new[]
        {
            SomeString, EmptyString
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ImplicitFromList_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<byte?>
        {
            0, 75, byte.MaxValue, 121, 235, null
        };

        FlatArray<byte?> actual = sourceList;

        sourceList[3] = 21;
        sourceList.Add(97);

        var expectedItems = new byte?[]
        {
            0, 75, byte.MaxValue, 121, 235, null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}