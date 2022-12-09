using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void GetEnumerator_SourceIsDefault_ExpectEnumeratorWithDefaultState()
    {
        var source = default(FlatArray<RefType>);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(Array.Empty<RefType>(), -1);
    }

    [Theory]
    [InlineData(1, PlusFifteen)]
    [InlineData(3, null, MinusFifteen, One, PlusFifteen, MinusOne)]
    public void GetEnumerator_SourceIsNotDefault_ExpectEnumeratorWithCorrectState(
        int length, params int?[] items)
    {
        var coppied = items.GetCopy();

        var source = items.InitializeFlatArray(length);
        var actual = source.GetEnumerator();

        var expectedItems = coppied.Take(length).ToArray();
        actual.VerifyInnerState(expectedItems, -1);
    }
}