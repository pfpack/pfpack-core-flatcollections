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
    public static void FilterWithIndex_PredicateIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { MinusFifteenIdRefType }.InitializeFlatArray();
        Func<RefType, int, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.Filter(predicate);
    }

    [Fact]
    public static void FilterWithIndex_SourceIsEmpty_ExpectDefault()
    {
        var source = default(FlatArray<StructType?>);

        var actual = source.Filter(Predicate);

        actual.VerifyInnerState(default, default);

        static bool Predicate(StructType? item, int _)
            =>
            true;
    }

    [Fact]
    public static void FilterWithIndex_SourceIsNotEmptyAndAllPredicatesReturnFalse_ExpectDefault()
    {
        var source = new decimal?[] { decimal.One, null, decimal.MaxValue }.InitializeFlatArray();

        var actual = source.Filter(Predicate);

        actual.VerifyInnerState(default, default);

        static bool Predicate(decimal? item, int _)
            =>
            false;
    }

    [Fact]
    public static void FilterWithIndex_SourceIsNotEmptyAndNotAllPredicatesReturnFalse_ExpectFilteredValues()
    {
        var mapper = new Dictionary<string, bool>
        {
            { EmptyString, true },
            { SomeString, false },
            { UpperAnotherString, true },
            { WhiteSpaceString, true },
            { AnotherString, false },
            { TabString, true }
        };

        var sourceItems = new[] { EmptyString, SomeString, UpperAnotherString, WhiteSpaceString, AnotherString };
        var source = mapper.Keys.ToArray().InitializeFlatArray(sourceItems.Length);

        var actual = source.Filter(Predicate);
        var expectedItems = new[] { EmptyString, UpperAnotherString, WhiteSpaceString };

        actual.VerifyTruncatedState(expectedItems);

        bool Predicate(string item, int index)
        {
            Assert.Equal(sourceItems[index], item);
            return mapper[item];
        }
    }
}