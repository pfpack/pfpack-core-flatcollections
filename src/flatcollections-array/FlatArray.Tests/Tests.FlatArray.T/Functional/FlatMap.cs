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
    public static void FlatMap_MapArgumentIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { MinusFifteenIdRefType, ZeroIdRefType }.InitializeFlatArray();
        Func<RefType, FlatArray<StructType>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMap_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RecordStruct?>);

        var actual = source.FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<string> Map(RecordStruct? _)
            =>
            new(SomeString, AnotherString);
    }

    [Theory]
    [MemberData(nameof(FlatMap_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault_CaseSource))]
    public static void FlatMap_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault(
        int[] source)
    {
        var actual = source.InitializeFlatArray().FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<long> Map(int sourceValue)
            =>
            default;
    }

    [Fact]
    public static void FlatMap_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<int, FlatArray<long>>
        {
            [-1] = default,
            [0] = new long[] { 0 }.InitializeFlatArray(),
            [1] = default,
            [2] = new long[] { 0, 1 }.InitializeFlatArray(0),
            [3] = new long[] { 0, 1, 2 }.InitializeFlatArray(),
            [4] = new long[] { 0, 1, 2, 3 }.InitializeFlatArray(),
            [5] = new long[] { 0, 1, 2, 3, 4 }.InitializeFlatArray(),
            [6] = new long[] { 0, 1, 2, 3, 4, 5 }.InitializeFlatArray(),
            [7] = new long[] { 0, 1, 2, 3, 4, 5, 6 }.InitializeFlatArray(),
            [8] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7 }.InitializeFlatArray(),
            [9] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }.InitializeFlatArray(),
            [10] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.InitializeFlatArray(),
            [11] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.InitializeFlatArray(),
            [12] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }.InitializeFlatArray(),
            [13] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }.InitializeFlatArray(),
            [14] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }.InitializeFlatArray(),
            [15] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, }.InitializeFlatArray(10),
            [16] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, }.InitializeFlatArray(),
            [17] = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }.InitializeFlatArray(16)
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray();

        var actual = source.FlatMap(Map);
        var expectedItems = new long[]
        {
            0,
            0, 1, 2,
            0, 1, 2, 3,
            0, 1, 2, 3, 4,
            0, 1, 2, 3, 4, 5,
            0, 1, 2, 3, 4, 5, 6,
            0, 1, 2, 3, 4, 5, 6, 7,
            0, 1, 2, 3, 4, 5, 6, 7, 8,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
        };

        actual.VerifyTruncatedState(expectedItems);

        FlatArray<long> Map(int sourceValue)
            =>
            mapper[sourceValue];
    }

    public static IEnumerable<object[]> FlatMap_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault_CaseSource()
    {
        yield return new object[]
        {
            new[] { 0  }
        };
        yield return new object[]
        {
            new[] { 0, 1  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  }
        };
        yield return new object[]
        {
            new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16  }
        };
    }
}