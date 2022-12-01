using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void EqualsWithObject_SourceIsDefaultAndObjectIsNull_ExpectFalse()
    {
        var source = default(FlatArray<RecordType?>);
        object? other = null;

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceIsDefaultAndObjectIsDefaultAnotherType_ExpectFalse()
    {
        var source = default(FlatArray<RecordType?>);
        object other = default(FlatArray<RefType?>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceIsDefaultAndObjectIsDefaultFlatArray_ExpectTrue()
    {
        var source = default(FlatArray<StructType>);
        object other = default(FlatArray<StructType>);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceIsDefaultAndObjectIsNotDefaultFlatArray_ExpectFalse()
    {
        var source = default(FlatArray<int>);

        object other = new[]
        {
            default(int)
        }
        .InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceIsNotDefaultAndObjectIsNull_ExpectFalse()
    {
        var source = new RefType?[]
        {
            null
        }
        .InitializeFlatArray();

        object? other = null;

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceIsNotDefaultAndObjectIsDefault_ExpectFalse()
    {
        var source = new string?[]
        {
            SomeString, AnotherString
        }
        .InitializeFlatArray();

        object other = default(FlatArray<string?>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceLengthIsNotEqualToObjectLength_ExpectFalse()
    {
        var items = new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, null };

        var source = items.InitializeFlatArray(3);
        object other = items.InitializeFlatArray(2);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceItemsAreEqualToObjectAnotherTypeItems_ExpectTrue()
    {
        var source = new int[] { 25, 31 }.InitializeFlatArray();
        object other = new long[] { 25, 31 }.InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceItemsAreEqualToObjectItems_ExpectTrue()
    {
        var source = new []
        {
            SomeString,
            null,
            EmptyString,
            AnotherString
        }
        .InitializeFlatArray();

        object other = new []
        {
            SomeString,
            null,
            EmptyString,
            AnotherString
        }
        .InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceItemsAreNotEqualToObjectItems_ExpectFalse()
    {
        var source = new int?[]
        {
            PlusFifteen,
            null,
            MinusOne
        }
        .InitializeFlatArray();

        object other = new int?[]
        {
            PlusFifteen,
            One,
            null
        }
        .InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsWithObject_SourceItemsOrderAreNotSameAsObjectItemsOrder_ExpectFalse()
    {
        var source = new[] { EmptyString, TabString }.InitializeFlatArray();
        object other = new[] { TabString, EmptyString }.InitializeFlatArray();

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}