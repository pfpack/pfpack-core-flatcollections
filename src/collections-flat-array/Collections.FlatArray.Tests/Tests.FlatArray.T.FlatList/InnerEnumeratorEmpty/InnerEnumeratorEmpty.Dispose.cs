using Xunit;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumeratorEmpty_Dispose_ExpectNothing()
    {
        var source = TestHelper.CreateFlatListEmptyEnumerator<string>();
        source.Dispose();
    }
}