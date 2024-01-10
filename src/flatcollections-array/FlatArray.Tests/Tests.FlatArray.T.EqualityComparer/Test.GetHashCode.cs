using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.EqualityComparerTestSource;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayEqualityComparerTest
{
    [Theory]
    [MemberData(nameof(Int32ItemHashCodeTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void GetHashCode_ItemTypeIsInt32_ExpectCorrectHashCode(
        FlatArray<int>.EqualityComparer source, FlatArray<int> array, int expected)
    {
        var actual = source.GetHashCode(array);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(StringItemHashCodeTestData), MemberType = typeof(EqualityComparerTestSource))]
    public void GetHashCode_ItemTypeIsString_ExpectCorrectHashCode(
        FlatArray<string?>.EqualityComparer source, FlatArray<string?> array, int expected)
    {
        var actual = source.GetHashCode(array);
        Assert.Equal(expected, actual);
    }
}