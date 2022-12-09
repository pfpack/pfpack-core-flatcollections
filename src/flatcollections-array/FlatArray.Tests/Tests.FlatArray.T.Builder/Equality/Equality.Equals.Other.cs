using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void EqualsWithOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
    {
        var source = default(FlatArray<string>.Builder);
        var other = default(FlatArray<string>.Builder);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceLengthIsNotEqualToOtherLength_ExpectFalse()
    {
        var items = new StructType?[] { SomeTextStructType, LowerSomeTextStructType, null };

        var source = items.InitializeFlatArrayBuilder(2);
        var other = items.InitializeFlatArrayBuilder(3);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceArrayIsSameAsOtherArray_ExpectTrue()
    {
        var items = new[] { decimal.MinusOne, decimal.MaxValue, decimal.MinusOne, default };

        var source = items.InitializeFlatArrayBuilder(4);
        var other = items.InitializeFlatArrayBuilder(4);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceArrayIsNotSameAsOtherArray_ExpectFalse()
    {
        var source = new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType }.InitializeFlatArrayBuilder();
        var other = new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType }.InitializeFlatArrayBuilder();

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}