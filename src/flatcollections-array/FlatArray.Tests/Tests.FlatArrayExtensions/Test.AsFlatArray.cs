using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(PlusFifteen)]
    public void AsFlatArray_ExpectInnerStateIsSourceItem(int? item)
    {
        var actual = item.AsFlatArray();

        const int expectedLength = 1;
        var expectedItems = new[] { item };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }
}