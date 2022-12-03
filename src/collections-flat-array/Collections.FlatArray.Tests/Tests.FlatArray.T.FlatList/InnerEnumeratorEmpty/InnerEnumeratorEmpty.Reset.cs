using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumeratorEmpty_Reset_ExpectNothing()
    {
        var source = TestHelper.CreateFlatListEmptyEnumerator<RecordStruct?>();
        source.Reset();
    }
}