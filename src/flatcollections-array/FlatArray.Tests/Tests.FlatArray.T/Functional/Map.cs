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
    public static void Map_MapArgumentIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { PlusFifteen, Zero, MinusOne }.InitializeFlatArray();
        Func<int, RecordType> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.Map(map);
    }

    [Fact]
    public static void Map_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RecordStruct>);

        var actual = source.Map(Map);

        actual.VerifyInnerState(default, default);

        static RefType Map(RecordStruct _)
            =>
            MinusFifteenIdRefType;
    }

    [Fact]
    public static void Map_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, RecordType>
        {
            [SomeString] = PlusFifteenIdLowerSomeStringNameRecord,
            [AnotherString] = ZeroIdNullNameRecord,
            [MixedWhiteSpacesString] = MinusFifteenIdSomeStringNameRecord
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(mapper.Keys.Count - 1);

        var actual = source.Map(Map);
        var expectedItems = new[] { PlusFifteenIdLowerSomeStringNameRecord, ZeroIdNullNameRecord };

        actual.VerifyTruncatedState(expectedItems);

        RecordType Map(string sourceValue)
            =>
            mapper[sourceValue];
    }
}