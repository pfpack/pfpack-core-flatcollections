using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Enumerator_Reset_ExpectIndexIsMinuOne()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType };
        var source = sourceItems.InitializeFlatListEnumerator(2, 1);

        source.Reset();

        var expectedItems = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType };
        source.VerifyFlatListEnumeratorState(2, expectedItems, -1);
    }
}