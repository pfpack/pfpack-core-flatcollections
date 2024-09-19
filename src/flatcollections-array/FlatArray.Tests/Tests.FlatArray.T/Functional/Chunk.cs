using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [MemberData(nameof(Chunk_InvalidSizeTestData))]
    public static void Chunk_SizeIsInvalid_ExpectArgumentOutOfRangeException(
        FlatArray<string> source, int size)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);
        Assert.Equal("size", ex.ParamName);

        void Test()
            =>
            _ = source.Chunk(size);
    }

    [Theory]
    [MemberData(nameof(Chunk_ValidTestData))]
    public static void Chunk_SizeIsValid_ExpectCorrectChunks(
        FlatArray<string> source, int size, string[][]? expectedChunks)
    {
        var actual = source.Chunk(size);
        actual.VerifyTruncatedState(expectedChunks);
    }

    public static TheoryData<FlatArray<string>, int> Chunk_InvalidSizeTestData
        =>
        new()
        {
            {
                default,
                0
            },
            {
                default,
                -1
            },
            {
                new[] { SomeString, AnotherString }.InitializeFlatArray(),
                0
            },
            {
                new[] { SomeString, AnotherString }.InitializeFlatArray(),
                -1
            }
        };

    public static TheoryData<FlatArray<string>, int, string[][]?> Chunk_ValidTestData
        =>
        new()
        {
            {
                default,
                1,
                null
            },
            {
                new[] { EmptyString }.InitializeFlatArray(0),
                1,
                null
            },
            {
                default,
                3,
                null
            },
            {
                new[] { SomeString, EmptyString, WhiteSpaceString, AnotherString }.InitializeFlatArray(3),
                2,
                [
                    [SomeString, EmptyString],
                    [WhiteSpaceString]
                ]
            },
            {
                new[] { SomeString, EmptyString, WhiteSpaceString, AnotherString }.InitializeFlatArray(4),
                2,
                [
                    [SomeString, EmptyString],
                    [WhiteSpaceString, AnotherString]
                ]
            },
            {
                new[] { SomeString, EmptyString, WhiteSpaceString, AnotherString, TabString }.InitializeFlatArray(5),
                2,
                [
                    [SomeString, EmptyString],
                    [WhiteSpaceString, AnotherString],
                    [TabString]
                ]
            },
            {
                new[] { ThreeWhiteSpacesString, AnotherString, SomeString, null! }.InitializeFlatArray(3),
                3,
                [
                    [ThreeWhiteSpacesString, AnotherString, SomeString]
                ]
            },
            {
                new[] { ThreeWhiteSpacesString, AnotherString, SomeString, null! }.InitializeFlatArray(4),
                3,
                [
                    [ThreeWhiteSpacesString, AnotherString, SomeString],
                    [null!]
                ]
            }
        };
}