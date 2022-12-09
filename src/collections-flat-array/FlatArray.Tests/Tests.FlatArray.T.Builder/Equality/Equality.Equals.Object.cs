using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void EqualsWithObject_SourceIsDefault_ExpectNotSupportedException()
    {
        var source = default(FlatArray<StructType>.Builder);

        try
        {
            _ = source.Equals(new object());
        }
        catch (NotSupportedException)
        {
            return;
        }

        Assert.Fail("An expected NotSupportedException was not thrown");
    }

    [Fact]
    public void EqualsWithObject_SourceIsNotDefault_ExpectNotSupportedException()
    {
        var source = new[] { SomeTextRecordStruct }.InitializeFlatArrayBuilder();

        try
        {
            _ = source.Equals(new object());
        }
        catch (NotSupportedException)
        {
            return;
        }

        Assert.Fail("An expected NotSupportedException was not thrown");
    }
}