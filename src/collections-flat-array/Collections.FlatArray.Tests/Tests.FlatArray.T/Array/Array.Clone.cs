using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Clone_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RefType?>);

        var actual = source.Clone();
        var expected = default(FlatArray<RefType?>);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clone_SourceIsNotDefault_ExpectClonedStateIsEqualToSourceState()
    {
        var sourceItems = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord, PlusFifteenIdSomeStringNameRecord
        };

        var source = TestHelper.Initialize(sourceItems);
        var actual = source.Clone();

        TestHelper.VerifyInnerState(sourceItems.Length, sourceItems, actual);
    }
}