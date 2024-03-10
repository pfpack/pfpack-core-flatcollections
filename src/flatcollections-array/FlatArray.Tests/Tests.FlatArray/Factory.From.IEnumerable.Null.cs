using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromEnumerable_SourceIsNull_ExpectInnerStateIsDefault()
    {
        IEnumerable<DateTime>? source = null;
        var actual = FlatArray<DateTime>.From(source);

        actual.VerifyInnerState_Default();
    }
}