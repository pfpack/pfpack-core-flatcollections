using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;
using static PrimeFuncPack.Core.Tests.EqualityComparerTestSource;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayEqualityComparerTest
{
    [Theory]
    [MemberData(nameof(GetStringDefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    [MemberData(nameof(GetIgnoreCaseStringEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_LeftIsDefaultAndRightIsDefault_ExpectTrue(
        FlatArray<string?>.EqualityComparer source)
    {
        var left = default(FlatArray<string?>);
        var right = default(FlatArray<string?>);

        var actual = source.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(GetInt32DefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_LeftIsDefaultAndRightIsNotDefault_ExpectFalse(
        FlatArray<int>.EqualityComparer source)
    {
        var left = default(FlatArray<int>);
        var right = new[] { PlusFifteen }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(GetStringDefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    [MemberData(nameof(GetIgnoreCaseStringEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_LeftIsNotDefaultAndRightIsDefault_ExpectFalse(
        FlatArray<string?>.EqualityComparer source)
    {
        var left = new string?[] { null }.InitializeFlatArray();
        var right = default(FlatArray<string?>);

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(GetInt32DefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_LeftLengthIsNotEqualToRightLength_ExpectFalse(
        FlatArray<int>.EqualityComparer source)
    {
        var items = new[] { MinusFifteen, int.MinValue, Zero, One, PlusFifteen, int.MinValue };

        var left = items.InitializeFlatArray(5);
        var right = items.InitializeFlatArray(4);

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(GetStringDefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_ComparerIsDefault_LeftItemsAreEqualToRightItems_ExpectTrue(
        FlatArray<string?>.EqualityComparer source)
    {
        var left = new[] { null, EmptyString, SomeString }.InitializeFlatArray();
        var right = new[] { null, EmptyString, SomeString }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(GetIgnoreCaseStringEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_ComparerIsIgnoreCaseComparer_LeftItemsAreEqualWithoutCaseToRightItems_ExpectTrue(
        FlatArray<string?>.EqualityComparer source)
    {
        var left = new[] { null, EmptyString, LowerSomeString }.InitializeFlatArray();
        var right = new[] { null, EmptyString, SomeString }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(GetStringDefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void Equals_LeftItemsAreNotEqualToRightItems_ExpectFalse(
        FlatArray<string?>.EqualityComparer source)
    {
        var left = new[] { null, EmptyString, LowerSomeString }.InitializeFlatArray();
        var right = new[] { null, EmptyString, SomeString }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(GetInt32DefaultEqualityComparerTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void DefaultItemComparer_Equals_LeftItemsOrderAreNotSameAsRightItemsOrder_ExpectFalse(
        FlatArray<int>.EqualityComparer source)
    {
        var left = new[] { PlusFifteen, Zero, MinusFifteen }.InitializeFlatArray();
        var right = new[] { PlusFifteen, MinusFifteen, Zero }.InitializeFlatArray();

        var actual = source.Equals(left, right);
        Assert.False(actual);
    }
}