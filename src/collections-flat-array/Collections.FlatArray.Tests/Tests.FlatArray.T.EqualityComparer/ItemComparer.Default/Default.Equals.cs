using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayEqualityComparerTest
{
    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftIsDefaultAndRightIsDefault_ExpectTrue(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<int?>(comparerFactory);

        var left = default(FlatArray<int?>);
        var right = default(FlatArray<int?>);

        var actual = source.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftIsDefaultAndRightIsNotDefault_ExpectFalse(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<RefType>(comparerFactory);

        var left = default(FlatArray<RefType>);
        var right = new[] { PlusFifteenIdRefType }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftIsNotDefaultAndRightIsDefault_ExpectFalse(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<decimal>(comparerFactory);

        var left = new decimal[] { default }.InitializeFlatArray();
        var right = default(FlatArray<decimal>);

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftLengthIsNotEqualToRightLength_ExpectFalse(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<RecordType>(comparerFactory);

        var items = new[] { MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord };

        var left = items.InitializeFlatArray(1);
        var right = items.InitializeFlatArray(2);

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftItemsAreEqualToRightItems_ExpectTrue(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<RecordStruct>(comparerFactory);

        var left = new RecordStruct[]
        {
            new() { Text = "First" },
            new() { Text = "Second" },
            new() { Text = "Third" }
        }
        .InitializeFlatArray();

        var right = new RecordStruct[]
        {
            new() { Text = "First" },
            new() { Text = "Second" },
            new() { Text = "Third" }
        }
        .InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftItemsAreNotEqualToRightItems_ExpectFalse(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<int>(comparerFactory);

        var left = new[] { One, MinusFifteen, int.MaxValue }.InitializeFlatArray();
        var right = new[] { MinusOne, MinusFifteen, int.MaxValue }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(DefaultComparerFactory.Default)]
    [InlineData(DefaultComparerFactory.Create)]
    [InlineData(DefaultComparerFactory.CreateWithNull)]
    public void DefaultItemComparer_Equals_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectFalse(
        DefaultComparerFactory comparerFactory)
    {
        var source = CreateComparerWithDefaultItemComparer<string?>(comparerFactory);

        var left = new[] { SomeString, AnotherString, null }.InitializeFlatArray();
        var right = new[] { null, AnotherString, SomeString }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }
}