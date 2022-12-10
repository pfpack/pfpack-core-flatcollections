using System;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void GetEnumerator_SourceIsDefault_ExpectEnumeratorWithDefaultState()
    {
        var source = default(FlatArray<RefType>);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(0, Array.Empty<RefType>(), -1);
    }

    [Theory]
    [InlineData(1, PlusFifteen)]
    [InlineData(3, null, MinusFifteen, One)]
    [InlineData(3, null, MinusFifteen, One, PlusFifteen, MinusOne)]
    public void GetEnumerator_SourceIsNotDefault_ExpectEnumeratorWithCorrectState(
        int length, params int?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatArray(length);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(length, copied, -1);
    }
}