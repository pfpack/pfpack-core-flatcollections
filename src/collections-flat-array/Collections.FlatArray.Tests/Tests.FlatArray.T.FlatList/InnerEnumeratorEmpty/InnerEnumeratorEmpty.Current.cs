using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumeratorEmpty_Current_ExpectInvalidOperationException()
    {
        var source = TestHelper.CreateFlatListEmptyEnumerator<RecordType>();
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.Current;
    }
}