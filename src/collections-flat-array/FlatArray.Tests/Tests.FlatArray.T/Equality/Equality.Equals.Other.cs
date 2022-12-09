using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void EqualsWithOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
    {
        var source = default(FlatArray<RefType>);
        var other = default(FlatArray<RefType>);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceIsDefaultAndOtherIsNotDefault_ExpectFalse()
    {
        var source = default(FlatArray<StructType>);

        var other = new[]
        {
            default(StructType)
        }
        .InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceIsNotDefaultAndOtherIsDefault_ExpectFalse()
    {
        var source = new object?[]
        {
            null
        }
        .InitializeFlatArray();

        var other = default(FlatArray<object?>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceLengthIsNotEqualToOtherLength_ExpectFalse()
    {
        var items = new[] { EmptyString, SomeString };

        var source = items.InitializeFlatArray(2);
        var other = items.InitializeFlatArray(1);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceItemsAreEqualToOtherItems_ExpectTrue()
    {
        var source = new RecordType?[]
        {
            new() { Id = MinusOne, Name = SomeString },
            new() { Id = int.MaxValue, Name = null },
            null,
            MinusFifteenIdSomeStringNameRecord,
            ZeroIdNullNameRecord
        }
        .InitializeFlatArray(4);

        var other = new RecordType?[]
        {
            new() { Id = MinusOne, Name = SomeString },
            new() { Id = int.MaxValue, Name = null },
            null,
            MinusFifteenIdSomeStringNameRecord
        }
        .InitializeFlatArray(4);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceItemsAreNotEqualToOtherItems_ExpectFalse()
    {
        var source = new RefType?[]
        {
            PlusFifteenIdRefType,
            new() { Id = int.MaxValue },
            null
        }
        .InitializeFlatArray();

        var other = new RefType?[]
        {
            PlusFifteenIdRefType,
            new() { Id = int.MaxValue },
            null
        }
        .InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithOther_SourceItemsOrderAreNotSameAsOtherItemsOrder_ExpectFalse()
    {
        var source = new[] { 1, 2, 3 }.InitializeFlatArray();
        var other = new[] { 1, 3, 2 }.InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}