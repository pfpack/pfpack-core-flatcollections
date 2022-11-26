using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Empty_ExpectInnerLengthIsZero()
    {
        var source = FlatArray<RecordType>.Empty;

        var actual = source.GetInnerLength();
        const int expected = 0;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Empty_ExpectInnerItemsIsNull()
    {
        var source = FlatArray<StructType?>.Empty;
        var actual = source.GetInnerItems();

        Assert.Null(actual);
    }
}