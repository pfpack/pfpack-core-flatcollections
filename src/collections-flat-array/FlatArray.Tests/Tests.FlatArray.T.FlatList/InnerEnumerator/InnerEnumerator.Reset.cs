using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumerator_Reset_ExpectIndexIsMinuOne()
    {
        var sourceItems = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType };
        var source = sourceItems.InitializeFlatListEnumerator(2, 1);

        source.Reset();

        var expectedItems = new[] { MinusFifteenIdRefType, null, PlusFifteenIdRefType };
        source.VerifyInnerFlatListEnumeratorState(expectedItems, 2, -1);
    }
}