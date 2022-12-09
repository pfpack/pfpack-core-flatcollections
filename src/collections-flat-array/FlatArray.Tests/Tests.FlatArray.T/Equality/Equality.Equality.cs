using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Equality_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(FlatArray<object>);
        var right = default(FlatArray<object>);

        var actual = left == right;
        Assert.True(actual);
    }

    [Fact]
    public void Equality_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
    {
        var left = default(FlatArray<RecordStruct>);

        var right = new RecordStruct[]
        {
            default
        }
        .InitializeFlatArray();

        var actual = left == right;
        Assert.False(actual);
    }

    [Fact]
    public void Equality_LeftIsNotDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = new RecordType?[]
        {
            null
        }
        .InitializeFlatArray();

        var right = default(FlatArray<RecordType?>);

        var actual = left == right;
        Assert.False(actual);
    }

    [Fact]
    public void Equality_LeftLengthIsNotEqualToRightLength_ExpectFalse()
    {
        var items = new[] { MinusOne, One };

        var left = items.InitializeFlatArray(2);
        var right = items.InitializeFlatArray(1);

        var actual = left == right;
        Assert.False(actual);
    }

    [Fact]
    public void Equality_LeftItemsAreEqualToRightItems_ExpectTrue()
    {
        var left = new[]
        {
            null,
            SomeString,
            EmptyString,
            AnotherString
        }
        .InitializeFlatArray(3);

        var right = new[]
        {
            null,
            SomeString,
            EmptyString
        }
        .InitializeFlatArray(3);

        var actual = left == right;
        Assert.True(actual);
    }

    [Fact]
    public void Equality_LeftItemsAreNotEqualToRightItems_ExpectFalse()
    {
        var left = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord
        }
        .InitializeFlatArray();

        var right = new[]
        {
            PlusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord
        }
        .InitializeFlatArray();

        var actual = left == right;
        Assert.False(actual);
    }

    [Fact]
    public void Equality_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectFalse()
    {
        var left = new[] { SomeTextRecordStruct, default }.InitializeFlatArray();
        var right = new[] { default, SomeTextRecordStruct }.InitializeFlatArray();

        var actual = left == right;
        Assert.False(actual);
    }
}