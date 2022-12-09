using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void Equality_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(FlatArray<RefType?>.Builder);
        var right = default(FlatArray<RefType?>.Builder);

        var actual = left == right;
        Assert.True(actual);
    }

    [Fact]
    public void Equality_LeftLengthIsNotEqualToRightLength_ExpectFalse()
    {
        var items = new[] { PlusFifteenIdRefType, ZeroIdRefType, null };

        var left = items.InitializeFlatArrayBuilder(3);
        var right = items.InitializeFlatArrayBuilder(2);

        var actual = left == right;
        Assert.False(actual);
    }

    [Fact]
    public void Equality_LeftArrayIsSameAsRightArray_ExpectTrue()
    {
        var items = new[] { Zero, MinusOne, PlusFifteen, int.MaxValue, MinusFifteen };

        var left = items.InitializeFlatArrayBuilder(3);
        var right = items.InitializeFlatArrayBuilder(3);

        var actual = left == right;
        Assert.True(actual);
    }

    [Fact]
    public void Equality_LeftArrayIsNotSameAsRightArray_ExpectFalse()
    {
        var left = new[] { SomeTextRecordStruct, default }.InitializeFlatArrayBuilder();
        var right = new[] { SomeTextRecordStruct, default }.InitializeFlatArrayBuilder();

        var actual = left == right;
        Assert.False(actual);
    }
}