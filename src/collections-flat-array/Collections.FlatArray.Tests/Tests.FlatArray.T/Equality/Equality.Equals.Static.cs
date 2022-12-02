using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void EqualsStatic_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(FlatArray<StructType?>);
        var right = default(FlatArray<StructType?>);

        var actual = FlatArray<StructType?>.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsStatic_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
    {
        var left = default(FlatArray<RefType?>);

        var right = new RefType?[]
        {
            null
        }
        .InitializeFlatArray();

        var actual = FlatArray<RefType?>.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsStatic_LeftIsNotDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = new[]
        {
            default(int)
        }
        .InitializeFlatArray();

        var right = default(FlatArray<int>);

        var actual = FlatArray<int>.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsStatic_LeftLengthIsNotEqualToRightLength_ExpectFalse()
    {
        var items = new[] { null, MinusFifteenIdRefType, ZeroIdRefType };

        var left = items.InitializeFlatArray(2);
        var right = items.InitializeFlatArray(3);

        var actual = FlatArray<RefType?>.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsStatic_LeftItemsAreEqualToRightItems_ExpectTrue()
    {
        var left = new[]
        {
            MinusFifteen,
            MinusOne,
            Zero
        }
        .InitializeFlatArray();

        var right = new[]
        {
            MinusFifteen,
            MinusOne,
            Zero
        }
        .InitializeFlatArray();

        var actual = FlatArray<int>.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsStatic_LeftItemsAreNotEqualToRightItems_ExpectFalse()
    {
        var left = new StructType[]
        {
            default, SomeTextStructType
        }
        .InitializeFlatArray();

        var right = new StructType[]
        {
            default, LowerSomeTextStructType
        }
        .InitializeFlatArray();

        var actual = FlatArray<StructType>.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsStatic_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectFalse()
    {
        var left = new[] { null, MinusFifteenIdRefType }.InitializeFlatArray();
        var right = new[] { MinusFifteenIdRefType, null }.InitializeFlatArray();

        var actual = FlatArray<RefType?>.Equals(left, right);
        Assert.False(actual);
    }
}