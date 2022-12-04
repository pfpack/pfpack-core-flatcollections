using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void Empty_ExpectInnerStateIsDefault()
    {
        var actual = FlatArray.Empty<RecordType>();
        actual.VerifyDefaultState();
    }
}