using System;
using System.Collections.Generic;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

internal static class EqualityComparerTestSource
{
    public static IEnumerable<object[]> GetInt32ItemHashCodeTestData()
    {
        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Default,
            default(FlatArray<int>),
            new HashCode().ToHashCode()
        };

        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Create(),
            default(FlatArray<int>),
            new HashCode().ToHashCode()
        };

        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Create(null),
            default(FlatArray<int>),
            new HashCode().ToHashCode()
        };

        var array = new[] { One, MinusFifteen, Zero, PlusFifteen }.InitializeFlatArray(3);

        var defaultItemComparer = EqualityComparer<int>.Default;
        var builder = new HashCode();

        builder.Add(defaultItemComparer.GetHashCode(One));
        builder.Add(defaultItemComparer.GetHashCode(MinusFifteen));
        builder.Add(defaultItemComparer.GetHashCode(Zero));

        var expectedHashCode = builder.ToHashCode();

        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Default,
            array,
            expectedHashCode
        };

        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Create(),
            array,
            expectedHashCode
        };

        yield return new object[]
        {
            FlatArray<int>.EqualityComparer.Create(null),
            array,
            expectedHashCode
        };
    }

    public static IEnumerable<object[]> GetStringItemHashCodeTestData()
    {
        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Default,
            default(FlatArray<string?>),
            new HashCode().ToHashCode()
        };

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(),
            default(FlatArray<string?>),
            new HashCode().ToHashCode()
        };

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(null),
            default(FlatArray<string?>),
            new HashCode().ToHashCode()
        };

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(StringComparer.InvariantCultureIgnoreCase),
            default(FlatArray<string?>),
            new HashCode().ToHashCode()
        };

        var firstArray = new[] { SomeString, null, EmptyString, WhiteSpaceString, TabString, AnotherString }.InitializeFlatArray(4);

        var defaultItemComparer = EqualityComparer<string?>.Default;
        var firstBuilder = new HashCode();

        firstBuilder.Add(defaultItemComparer.GetHashCode(SomeString));
        firstBuilder.Add(0);
        firstBuilder.Add(defaultItemComparer.GetHashCode(EmptyString));
        firstBuilder.Add(defaultItemComparer.GetHashCode(WhiteSpaceString));

        var firstExpectedHashCode = firstBuilder.ToHashCode();

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Default,
            firstArray,
            firstExpectedHashCode
        };

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(),
            firstArray,
            firstExpectedHashCode
        };

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(null),
            firstArray,
            firstExpectedHashCode
        };

        var secondArray = new[] { AnotherString, SomeString, null, LowerAnotherString }.InitializeFlatArray(3);

        var secondItemComparer = StringComparer.InvariantCultureIgnoreCase;
        var secondBuilder = new HashCode();

        secondBuilder.Add(secondItemComparer.GetHashCode(AnotherString));
        secondBuilder.Add(secondItemComparer.GetHashCode(SomeString));
        secondBuilder.Add(0);

        var secondExpectedHashCode = secondBuilder.ToHashCode();

        yield return new object[]
        {
            FlatArray<string?>.EqualityComparer.Create(secondItemComparer),
            secondArray,
            secondExpectedHashCode
        };
    }

    public static IEnumerable<object[]> GetInt32DefaultEqualityComparerTestData()
        =>
        new[]
        {
            new object[]
            {
                FlatArray<int>.EqualityComparer.Default
            },
            new object[]
            {
                FlatArray<int>.EqualityComparer.Create()
            },
            new object[]
            {
                FlatArray<int>.EqualityComparer.Create(null)
            }
        };

    public static IEnumerable<object[]> GetStringDefaultEqualityComparerTestData()
        =>
        new[]
        {
            new object[]
            {
                FlatArray<string?>.EqualityComparer.Default
            },
            new object[]
            {
                FlatArray<string?>.EqualityComparer.Create()
            },
            new object[]
            {
                FlatArray<string?>.EqualityComparer.Create(null)
            }
        };

    public static IEnumerable<object[]> GetIgnoreCaseStringEqualityComparerTestData()
        =>
        new[]
        {
            new object[]
            {
                FlatArray<string?>.EqualityComparer.Create(StringComparer.InvariantCultureIgnoreCase)
            }
        };
}