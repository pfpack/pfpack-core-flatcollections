using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Empty_ExpectInnerStateIsDefault()
    {
        var actual = FlatArray<StructType?>.Empty;
        actual.VerifyInnerState_Default();
    }
}