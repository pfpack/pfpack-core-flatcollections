using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void GetHashCode_SourceIsDefault_ExpectNotSupportedException()
    {
        var source = default(FlatArray<RecordType>.Builder);

        try
        {
            _ = source.GetHashCode();
        }
        catch (NotSupportedException)
        {
            return;
        }

        Assert.Fail("An expected NotSupportedException was not thrown");
    }

    [Fact]
    public void GetHashCode_SourceIsNotDefault_ExpectNotSupportedException()
    {
        var source = new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType }.InitializeFlatArrayBuilder(2);

        try
        {
            _ = source.GetHashCode();
        }
        catch (NotSupportedException)
        {
            return;
        }

        Assert.Fail("An expected NotSupportedException was not thrown");
    }
}