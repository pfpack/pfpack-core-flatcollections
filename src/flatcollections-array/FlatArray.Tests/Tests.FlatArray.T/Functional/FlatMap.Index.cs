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

    [Fact]
    public static void FlatMapWithIndex_SourceIsNotDefaultAndAllMapResultAreDefault_ExpectDefault()
    {
        var source = new[] { EmptyString, SomeString, WhiteSpaceString }.InitializeFlatArray();

        var actual = source.FlatMap(Map);

        actual.VerifyInnerState(default, default);

        static FlatArray<StructType> Map(string sourceValue, int index)
            =>
            default;
    }

    [Fact]
    public static void FlatMapWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, FlatArray<decimal?>>
        {
            [SomeString] = default,
            [AnotherString] = new decimal?[] { decimal.MinusOne, null, decimal.MaxValue }.InitializeFlatArray(2),
            [WhiteSpaceString] = new decimal?[] { null }.InitializeFlatArray(),
            [UpperSomeString] = new decimal?[] { decimal.One }.InitializeFlatArray(),
            [LowerSomeString] = new decimal?[] { decimal.MinusOne }.InitializeFlatArray()
        };

        var sourceItems = new[] { SomeString, AnotherString, WhiteSpaceString, UpperSomeString };
        var source = mapper.Keys.ToArray().InitializeFlatArray(sourceItems.Length);

        var actual = source.FlatMap(Map);
        var expectedItems = new decimal?[] { decimal.MinusOne, null, null, decimal.One };

        actual.VerifyTruncatedState(expectedItems);

        FlatArray<decimal?> Map(string sourceValue, int index)
        {
            Assert.Equal(sourceItems[index], sourceValue);
            return mapper[sourceValue];
        }
    }
}