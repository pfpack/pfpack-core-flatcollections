using System;
using System.Collections.Generic;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests.TestData;

internal class ReadingCollectionsTestSource
{
    public static IEnumerable<object?[]> EnumerateStringNonEmptyCases()
    {
        yield return new object[]
        {
            new string?[] { null },
            new string?[] { null, null, null, null }
        };
        yield return new object[]
        {
            new string[] { SomeString },
            new string?[] { SomeString, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { SomeString, null },
            new string?[] { SomeString, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { null, SomeString },
            new string?[] { null, SomeString, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0" },
            new string?[] { "0", null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1" },
            new string?[] { "0", "1", null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2" },
            new string?[] { "0", "1", "2", null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3" },
            new string?[] { "0", "1", "2", "3" }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4" },
            new string?[] { "0", "1", "2", "3", "4", null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5" },
            new string?[] { "0", "1", "2", "3", "4", "5", null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7" }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", null, null, null, null, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", null, null, null, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", null, null, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", null, null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", null, null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", null, null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", null }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" }
        };
        yield return new object[]
        {
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" },
            new string?[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
        };
    }

    public static IEnumerable<object?[]> EnumerateInt32NullableNonEmptyCases()
    {
        yield return new object[]
        {
            new int?[] { null },
            new int?[] { null, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { MinusFifteen },
            new int?[] { MinusFifteen, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { MinusFifteen, null },
            new int?[] { MinusFifteen, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { null, MinusFifteen },
            new int?[] { null, MinusFifteen, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0 },
            new int?[] { 0, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1 },
            new int?[] { 0, 1, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2 },
            new int?[] { 0, 1, 2, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3 },
            new int?[] { 0, 1, 2, 3 }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4 },
            new int?[] { 0, 1, 2, 3, 4, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5 },
            new int?[] { 0, 1, 2, 3, 4, 5, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7 }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, null, null, null, null, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, null, null, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, null, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, null, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, null, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, null }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
        };
        yield return new object[]
        {
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
        };
    }
}
