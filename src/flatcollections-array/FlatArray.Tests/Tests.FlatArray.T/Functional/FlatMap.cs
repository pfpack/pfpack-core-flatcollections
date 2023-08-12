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

    [Fact]
    public static void FlatMap_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault()
    {
        var source = new[] { SomeTextStructType, LowerSomeTextStructType }.InitializeFlatArray();

        var actual = source.FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<RefType> Map(StructType sourceValue)
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
}