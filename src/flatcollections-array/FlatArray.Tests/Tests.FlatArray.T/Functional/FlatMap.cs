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
        var mapper = new Dictionary<int, FlatArray<RecordType?>>
        {
            [MinusFifteen] = new RecordType?[] { MinusFifteenIdSomeStringNameRecord }.InitializeFlatArray(),
            [One] = default,
            [int.MaxValue] = new RecordType?[] { PlusFifteenIdSomeStringNameRecord, null, ZeroIdNullNameRecord }.InitializeFlatArray(2),
            [PlusFifteen] = new RecordType?[] { MinusFifteenIdNullNameRecord }.InitializeFlatArray()
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(3);

        var actual = source.FlatMap(Map);
        var expectedItems = new RecordType?[] { MinusFifteenIdSomeStringNameRecord, PlusFifteenIdSomeStringNameRecord, null };

        actual.VerifyTruncatedState(expectedItems);

        FlatArray<RecordType?> Map(int sourceValue)
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