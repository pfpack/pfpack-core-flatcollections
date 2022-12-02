using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Empty_ExpectInnerStateIsDefault()
    {
        var actual = FlatArray<StructType?>.Empty;
        TestHelper.VerifyDefaultState(actual);
    }
}