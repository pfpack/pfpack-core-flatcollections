using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void EqualsStatic_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(FlatArray<StructType?>.Builder);
        var right = default(FlatArray<StructType?>.Builder);

        var actual = FlatArray<StructType?>.Builder.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsStatic_LeftLengthIsNotEqualToRightLength_ExpectFalse()
    {
        var items = new[] { MinusFifteen, Zero, PlusFifteen, One, MinusOne, int.MinValue };

        var left = items.InitializeFlatArrayBuilder(5);
        var right = items.InitializeFlatArrayBuilder(6);

        var actual = FlatArray<int>.Builder.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsStatic_LeftArrayIsSameAsRightArray_ExpectTrue()
    {
        var items = new[] { SomeTextRecordStruct, UpperAnotherTextRecordStruct, AnotherTextRecordStruct };

        var left = items.InitializeFlatArrayBuilder(2);
        var right = items.InitializeFlatArrayBuilder(2);

        var actual = FlatArray<RecordStruct>.Builder.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsStatic_LeftArrayIsNotSameAsRightArray_ExpectFalse()
    {
        var left = new[] { PlusFifteenIdLowerSomeStringNameRecord, ZeroIdNullNameRecord, null }.InitializeFlatArrayBuilder();
        var right = new[] { PlusFifteenIdLowerSomeStringNameRecord, ZeroIdNullNameRecord, null }.InitializeFlatArrayBuilder();

        var actual = FlatArray<RecordType?>.Builder.Equals(left, right);
        Assert.False(actual);
    }
}