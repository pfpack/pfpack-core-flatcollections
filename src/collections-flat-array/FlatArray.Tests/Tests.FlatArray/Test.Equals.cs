using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void Equals_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(FlatArray<RecordType?>);
        var right = default(FlatArray<RecordType?>);

        var actual = FlatArray.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void Equals_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
    {
        var left = default(FlatArray<StructType>);
        var right = new StructType[] { default } .InitializeFlatArray();

        var actual = FlatArray.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void Equals_LeftIsNotDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = new string?[] { null }.InitializeFlatArray();
        var right = default(FlatArray<string?>);

        var actual = FlatArray.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void Equals_LeftLengthIsNotEqualToRightLength_ExpectFalse()
    {
        var items = new[] { PlusFifteen, MinusOne, int.MaxValue, Zero, One };

        var left = items.InitializeFlatArray(4);
        var right = items.InitializeFlatArray(3);

        var actual = FlatArray.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void Equals_LeftItemsAreEqualToRightItems_ExpectTrue()
    {
        var left = new[] { null, SomeString, AnotherString }.InitializeFlatArray(3);
        var right = new[] { null, SomeString, AnotherString }.InitializeFlatArray(3);

        var actual = FlatArray.Equals(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void Equals_LeftItemsAreNotEqualToRightItems_ExpectFalse()
    {
        var left = new[] { true, false }.InitializeFlatArray();
        var right = new[] { false, true }.InitializeFlatArray();

        var actual = FlatArray.Equals(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void Equals_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectFalse()
    {
        var left = new[] { SomeTextStructType, default }.InitializeFlatArray();
        var right = new[] { default, SomeTextStructType }.InitializeFlatArray();

        var actual = FlatArray.Equals(left, right);
        Assert.False(actual);
    }
}