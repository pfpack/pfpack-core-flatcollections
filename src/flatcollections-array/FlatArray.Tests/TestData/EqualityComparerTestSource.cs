using System;
using System.Collections.Generic;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

internal static class EqualityComparerTestSource
{
    public static TheoryData<FlatArray<int>.EqualityComparer, FlatArray<int>, int> Int32ItemHashCodeTestData
    {
        get
        {
            var data = new TheoryData<FlatArray<int>.EqualityComparer, FlatArray<int>, int>
            {
                {
                    FlatArray<int>.EqualityComparer.Default,
                    default,
                    new HashCode().ToHashCode()
                },
                {
                    FlatArray<int>.EqualityComparer.Create(),
                    default,
                    new HashCode().ToHashCode()
                },
                {
                    FlatArray<int>.EqualityComparer.Create(null),
                    default,
                    new HashCode().ToHashCode()
                }
            };

            var array = new[] { One, MinusFifteen, Zero, PlusFifteen }.InitializeFlatArray(3);

            var defaultItemComparer = EqualityComparer<int>.Default;
            var builder = new HashCode();

            builder.Add(defaultItemComparer.GetHashCode(One));
            builder.Add(defaultItemComparer.GetHashCode(MinusFifteen));
            builder.Add(defaultItemComparer.GetHashCode(Zero));

            var expectedHashCode = builder.ToHashCode();

            data.Add(FlatArray<int>.EqualityComparer.Default, array, expectedHashCode);
            data.Add(FlatArray<int>.EqualityComparer.Create(), array, expectedHashCode);
            data.Add(FlatArray<int>.EqualityComparer.Create(null), array, expectedHashCode);

            return data;
        }
    }

    public static TheoryData<FlatArray<string?>.EqualityComparer, FlatArray<string?>, int> StringItemHashCodeTestData
    {
        get
        {
            var data = new TheoryData<FlatArray<string?>.EqualityComparer, FlatArray<string?>, int>
            {
                {
                    FlatArray<string?>.EqualityComparer.Default,
                    default,
                    new HashCode().ToHashCode()
                },
                {
                    FlatArray<string?>.EqualityComparer.Create(),
                    default,
                    new HashCode().ToHashCode()
                },
                {
                    FlatArray<string?>.EqualityComparer.Create(null),
                    default,
                    new HashCode().ToHashCode()
                },
                {
                    FlatArray<string?>.EqualityComparer.Create(StringComparer.InvariantCultureIgnoreCase),
                    default,
                    new HashCode().ToHashCode()
                }
            };

            var firstArray = new[] { SomeString, null, EmptyString, WhiteSpaceString, TabString, AnotherString }.InitializeFlatArray(4);

            var defaultItemComparer = EqualityComparer<string?>.Default;
            var firstBuilder = new HashCode();

            firstBuilder.Add(defaultItemComparer.GetHashCode(SomeString));
            firstBuilder.Add(0);
            firstBuilder.Add(defaultItemComparer.GetHashCode(EmptyString));
            firstBuilder.Add(defaultItemComparer.GetHashCode(WhiteSpaceString));

            var firstExpectedHashCode = firstBuilder.ToHashCode();

            data.Add(FlatArray<string?>.EqualityComparer.Default, firstArray, firstExpectedHashCode);
            data.Add(FlatArray<string?>.EqualityComparer.Create(), firstArray, firstExpectedHashCode);
            data.Add(FlatArray<string?>.EqualityComparer.Create(null), firstArray, firstExpectedHashCode);

            var secondArray = new[] { AnotherString, SomeString, null, LowerAnotherString }.InitializeFlatArray(3);

            var secondItemComparer = StringComparer.InvariantCultureIgnoreCase;
            var secondBuilder = new HashCode();

            secondBuilder.Add(secondItemComparer.GetHashCode(AnotherString));
            secondBuilder.Add(secondItemComparer.GetHashCode(SomeString));
            secondBuilder.Add(0);

            var secondExpectedHashCode = secondBuilder.ToHashCode();
            data.Add(FlatArray<string?>.EqualityComparer.Create(secondItemComparer), secondArray, secondExpectedHashCode);

            return data;
        }
    }

    public static TheoryData<FlatArray<int>.EqualityComparer> Int32DefaultEqualityComparerTestData
        =>
        new()
        {
            {
                FlatArray<int>.EqualityComparer.Default
            },
            {
                FlatArray<int>.EqualityComparer.Create()
            },
            {
                FlatArray<int>.EqualityComparer.Create(null)
            }
        };

    public static TheoryData<FlatArray<string?>.EqualityComparer> StringDefaultEqualityComparerTestData
        =>
        new()
        {
            {
                FlatArray<string?>.EqualityComparer.Default
            },
            {
                FlatArray<string?>.EqualityComparer.Create()
            },
            {
                FlatArray<string?>.EqualityComparer.Create(null)
            }
        };

    public static TheoryData<FlatArray<string?>.EqualityComparer> IgnoreCaseStringEqualityComparerTestData
        =>
        new()
        {
            {
                FlatArray<string?>.EqualityComparer.Create(StringComparer.InvariantCultureIgnoreCase)
            }
        };
}