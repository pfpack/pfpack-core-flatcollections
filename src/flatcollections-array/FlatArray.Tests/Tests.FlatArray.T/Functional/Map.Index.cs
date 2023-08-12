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
    public static void MapWithIndex_MapArgumentIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new RefType?[] { PlusFifteenIdRefType, MinusFifteenIdRefType }.InitializeFlatArray();
        Func<RefType?, int, RecordType> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.Map(map);
    }

    [Fact]
    public static void MapWithIndex_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<string>);

        var actual = source.Map(Map);

        actual.VerifyInnerState(default, default);

        static RecordType? Map(string _, int index)
            =>
            ZeroIdNullNameRecord;
    }

    [Fact]
    public static void MapWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<RefType, string?>
        {
            [MinusFifteenIdRefType] = SomeString,
            [PlusFifteenIdRefType] = null,
            [ZeroIdRefType] = AnotherString
        };

        var sourceItems = new[] { MinusFifteenIdRefType, PlusFifteenIdRefType };
        var source = mapper.Keys.ToArray().InitializeFlatArray(sourceItems.Length);

        var actual = source.Map(Map);
        var expectedItems = new[] { SomeString, null };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);

        string? Map(RefType sourceValue, int index)
        {
            Assert.Equal(sourceItems[index], sourceValue);
            return mapper[sourceValue];
        }
    }
}