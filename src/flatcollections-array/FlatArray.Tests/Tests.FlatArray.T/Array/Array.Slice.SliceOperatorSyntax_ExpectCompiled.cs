using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Slice_SliceOperatorSyntax_ExpectCompiled()
    {
        _ = default(FlatArray<int>)[..0];
        Assert.True(true);
    }
}
