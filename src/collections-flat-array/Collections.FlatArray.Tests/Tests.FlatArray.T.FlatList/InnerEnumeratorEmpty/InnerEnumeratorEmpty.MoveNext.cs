using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumeratorEmpty_MoveNext_ExpectFalse()
    {
        var source = TestHelper.CreateFlatListEmptyEnumerator<RefType?>();
        var actual = source.MoveNext();

        Assert.False(actual);
    }
}