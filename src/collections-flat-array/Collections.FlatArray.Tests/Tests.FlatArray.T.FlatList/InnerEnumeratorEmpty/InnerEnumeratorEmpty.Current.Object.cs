using System;
using System.Collections;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

public sealed partial class FlatArrayFlatListTest
{
    [Fact]
    public void InnerEnumeratorEmpty_CurrentObject_ExpectInvalidOperationException()
    {
        var source = (IEnumerator)TestHelper.CreateFlatListEmptyEnumerator<StructType>();
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.Current;
    }
}