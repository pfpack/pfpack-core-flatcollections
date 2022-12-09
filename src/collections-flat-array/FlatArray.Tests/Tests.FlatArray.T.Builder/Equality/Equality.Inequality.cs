using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void Inequality_LeftIsDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = default(FlatArray<RecordStruct?>.Builder);
        var right = default(FlatArray<RecordStruct?>.Builder);

        var actual = left != right;
        Assert.False(actual);
    }

    [Fact]
    public void Inequality_LeftLengthIsNotEqualToRightLength_ExpectTrue()
    {
        var items = new[] { One, int.MinValue, Zero, PlusFifteen, One, MinusFifteen, int.MaxValue };

        var left = items.InitializeFlatArrayBuilder(4);
        var right = items.InitializeFlatArrayBuilder(5);

        var actual = left != right;
        Assert.True(actual);
    }

    [Fact]
    public void Inequality_LeftArrayIsSameAsRightArray_ExpectFalse()
    {
        var items = new RecordStruct?[] { SomeTextRecordStruct, null, AnotherTextRecordStruct };

        var left = items.InitializeFlatArrayBuilder(2);
        var right = items.InitializeFlatArrayBuilder(2);

        var actual = left != right;
        Assert.False(actual);
    }

    [Fact]
    public void Inequality_LeftArrayIsNotSameAsRightArray_ExpectTrue()
    {
        var left = new[] { SomeString, AnotherString, TabString, WhiteSpaceString }.InitializeFlatArrayBuilder();
        var right = new[] { SomeString, AnotherString, TabString, WhiteSpaceString }.InitializeFlatArrayBuilder();

        var actual = left != right;
        Assert.True(actual);
    }
}