using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void GetHashCode_FirstIsDefaultAndSecondIsDefaultAnotherType_ExpectDifferentHashCodes()
    {
        var first = default(FlatArray<object>);
        var second = default(FlatArray<RefType>);

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceIsDefaultAndSecondIsDefault_ExpectEqualHashCodes()
    {
        var first = default(FlatArray<RecordType?>);
        var second = default(FlatArray<RecordType?>);

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.True(actual);
    }

    [Fact]
    public void GetHashCode_SourceIsDefaultAndSecondIsNotDefault_ExpectDifferentHashCodes()
    {
        var first = default(FlatArray<string?>);
        var second = new string?[] { null }.InitializeFlatArray();

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceIsNotDefaultAndSecondIsDefault_ExpectDifferentHashCodes()
    {
        var first = new[] { false, true }.InitializeFlatArray();
        var second = default(FlatArray<bool>);

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceLengthIsNotEqualToSecondLength_ExpectDifferentHashCodes()
    {
        var items = new int?[] { Zero, PlusFifteen, One };

        var first = items.InitializeFlatArray(2);
        var second = items.InitializeFlatArray(3);

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceItemsAreEqualToSecondAnotherTypeItems_ExpectDifferentHashCodes()
    {
        var first = new StructType?[] { SomeTextStructType, AnotherTextStructType }.InitializeFlatArray();
        var second = new StructType[] { SomeTextStructType, AnotherTextStructType }.InitializeFlatArray();

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceItemsAreEqualToSecondItems_ExpectEqualHashCodes()
    {
        var first = new RecordType?[]
        {
            new() { Id = One },
            null,
            new() { Id = MinusFifteen, Name = "Some name" }
        }
        .InitializeFlatArray();

        var second = new RecordType?[]
        {
            new() { Id = One },
            null,
            new() { Id = MinusFifteen, Name = "Some name" }
        }
        .InitializeFlatArray();

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.True(actual);
    }

    [Fact]
    public void GetHashCode_SourceItemsAreNotEqualToSecondItems_ExpectDifferentHashCodes()
    {
        var first = new[] { SomeString, EmptyString, WhiteSpaceString }.InitializeFlatArray();
        var second = new[] { SomeString, EmptyString, TabString }.InitializeFlatArray();

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }

    [Fact]
    public void GetHashCode_SourceItemsOrderAreNotSameAsSecondItemsOrder_ExpectDifferentHashCodes()
    {
        var first = new int?[] { One, null, PlusFifteen }.InitializeFlatArray();
        var second = new int?[] { One, PlusFifteen, null }.InitializeFlatArray();

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        var actual = firstHashCode == secondHashCode;
        Assert.False(actual);
    }
}