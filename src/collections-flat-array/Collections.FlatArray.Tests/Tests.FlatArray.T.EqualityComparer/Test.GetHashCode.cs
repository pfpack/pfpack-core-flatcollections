using System.Collections.Generic;
using Xunit;
using static PrimeFuncPack.Collections.Tests.FlatArrayEqualityComparerTestSource;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayEqualityComparerTest
{
    [Theory]
    [MemberData(nameof(GetInt32ItemHashCodeTestData), MemberType = typeof(FlatArrayEqualityComparerTestSource))]
    public void GetHashCode_ItemTypeIsInt32_ExpectCorrectHashCode(
        FlatArray<int>.EqualityComparer source, FlatArray<int> array, int expected)
    {
        var actual = source.GetHashCode(array);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetStringItemHashCodeTestData), MemberType = typeof(FlatArrayEqualityComparerTestSource))]
    public void GetHashCode_ItemTypeIsString_ExpectCorrectHashCode(
        FlatArray<string?>.EqualityComparer source, FlatArray<string?> array, int expected)
    {
        var actual = source.GetHashCode(array);
        Assert.Equal(expected, actual);
    }
}