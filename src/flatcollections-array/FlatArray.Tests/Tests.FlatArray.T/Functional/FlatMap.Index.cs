using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void FlatMapWithIndex_MapArgumentIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { long.MinValue, long.MaxValue }.InitializeFlatArray();
        Func<long, int, FlatArray<object>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMapWithIndex_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<StructType>);

        var actual = source.FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<RecordStruct?> Map(StructType _, int index)
            =>
            new(null, SomeTextRecordStruct, AnotherTextRecordStruct);
    }

    [Theory]
    [MemberData(nameof(FlatMapWithIndex_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault_CaseSource))]
    public static void FlatMapWithIndex_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault(
        int[] source)
    {
        var actual = source.InitializeFlatArray().FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<long> Map(int sourceValue, int index)
            =>
            default;
    }

    [Fact]
    public static void FlatMapWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<int, FlatArray<decimal?>>
        {
            [-1] = new decimal?[] { 8, 4, 2, 1 }.InitializeFlatArray(3),
            [0] = default,
            [1] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }.InitializeFlatArray(),
            [2] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }.InitializeFlatArray(),
            [3] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }.InitializeFlatArray(),
            [4] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }.InitializeFlatArray(),
            [5] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }.InitializeFlatArray(),
            [6] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }.InitializeFlatArray(),
            [7] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.InitializeFlatArray(),
            [8] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.InitializeFlatArray(),
            [9] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7, 8 }.InitializeFlatArray(),
            [10] = new decimal?[] { null, 1, 2, 3, 4, 5, 6, 7 }.InitializeFlatArray(),
            [11] = new decimal?[] { null, 1, 2, 3, 4, 5, 6 }.InitializeFlatArray(),
            [12] = new decimal?[] { null, 1, 2, 3, 4, 5 }.InitializeFlatArray(),
            [13] = new decimal?[] { null, 1, 2, 3, 4 }.InitializeFlatArray(),
            [14] = new decimal?[] { null, 1, 2, 3 }.InitializeFlatArray(),
            [15] = new decimal?[] { null, 1, 2 }.InitializeFlatArray(),
            [16] = new decimal?[] { null, 1 }.InitializeFlatArray(1),
            [17] = default,
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray();

        var actual = source.FlatMap(Map);
        var expectedItems = new decimal?[]
        {
            8, 4, 2,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            null, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            null, 1, 2, 3, 4, 5, 6, 7, 8,
            null, 1, 2, 3, 4, 5, 6, 7,
            null, 1, 2, 3, 4, 5, 6,
            null, 1, 2, 3, 4, 5,
            null, 1, 2, 3, 4,
            null, 1, 2, 3,
            null, 1, 2,
            null
        };

        actual.VerifyTruncatedState(expectedItems);

        FlatArray<decimal?> Map(int sourceValue)
            =>
            mapper[sourceValue];
    }

    public static TheoryData<int[]> FlatMapWithIndex_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault_CaseSource
        =>
        new()
        {
            {
                [ 0 ]
            },
            {
                [ 0, 1 ]
            },
            {
                [ 0, 1, 2 ]
            },
            {
                [ 0, 1, 2, 3 ]
            },
            {
                [ 0, 1, 2, 3, 4 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ]
            },
            {
                [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 ]
            }
        };
}