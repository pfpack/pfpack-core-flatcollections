using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Inequality_LeftIsDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = default(FlatArray<long?>);
        var right = default(FlatArray<long?>);

        var actual = left != right;
        Assert.False(actual);
    }

    [Fact]
    public void Inequality_LeftIsDefaultAndRightIsNotDefault_ExpectTrue()
    {
        var left = default(FlatArray<RefType?>);

        var right = new RefType?[]
        {
            PlusFifteenIdRefType
        }
        .InitializeFlatArray();

        var actual = left != right;
        Assert.True(actual);
    }

    [Fact]
    public void Inequality_LeftIsNotDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = new byte?[]
        {
            null
        }
        .InitializeFlatArray();

        var right = default(FlatArray<byte?>);

        var actual = left != right;
        Assert.True(actual);
    }

    [Fact]
    public void Inequality_LeftLengthIsNotEqualToRightLength_ExpectTrue()
    {
        var items = new bool?[] { true, null, false };

        var left = items.InitializeFlatArray(3);
        var right = items.InitializeFlatArray(2);

        var actual = left != right;
        Assert.True(actual);
    }

    [Fact]
    public void Inequality_LeftItemsAreEqualToRightItems_ExpectFalse()
    {
        var left = new object?[]
        {
            null,
            new { Id = One, Name = SomeString },
            new { Id = PlusFifteen, Name = AnotherString }
        }
        .InitializeFlatArray();

        var right = new object?[]
        {
            null,
            new { Id = One, Name = SomeString },
            new { Id = PlusFifteen, Name = AnotherString }
        }
        .InitializeFlatArray();

        var actual = left != right;
        Assert.False(actual);
    }

    [Fact]
    public void Inequality_LeftItemsAreNotEqualToRightItems_ExpectTrue()
    {
        var left = new[]
        {
            decimal.One, decimal.MaxValue
        }
        .InitializeFlatArray();

        var right = new[]
        {
            decimal.MinusOne, decimal.MaxValue
        }
        .InitializeFlatArray();

        var actual = left != right;
        Assert.True(actual);
    }

    [Fact]
    public void Inequality_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectTrue()
    {
        var left = new[] { MinusFifteenIdRefType, ZeroIdRefType, PlusFifteenIdRefType }.InitializeFlatArray();
        var right = new[] { PlusFifteenIdRefType, ZeroIdRefType, MinusFifteenIdRefType }.InitializeFlatArray();

        var actual = left != right;
        Assert.True(actual);
    }
}