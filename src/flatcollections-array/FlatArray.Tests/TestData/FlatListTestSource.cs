using System;
using System.Collections.Generic;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

internal static class FlatListTestSource
{
    public static IEnumerable<object[]> GetRecordTypeCopyToInRangeTestData()
        =>
        new[]
        {
            new object[]
            {
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord
                }
                .InitializeFlatList(),
                new[]
                {
                    null,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord
                }
            },
            new object[]
            {
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord
                }
                .InitializeFlatList(),
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                }
            },
            new object[]
            {
                new[]
                {
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord
                }.InitializeFlatList(),
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    MinusFifteenIdNullNameRecord,
                    null,
                    new()
                },
                1,
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord
                }
            },
            new object[]
            {
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord
                }.InitializeFlatList(),
                new[]
                {
                    ZeroIdNullNameRecord,
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                },
                1,
                new[]
                {
                    ZeroIdNullNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                }
            }
        };
}