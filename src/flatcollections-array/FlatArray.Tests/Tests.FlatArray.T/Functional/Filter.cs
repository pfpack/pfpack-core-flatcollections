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
    public static void Filter_PredicateIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { SomeString, LowerSomeString }.InitializeFlatArray();
        Predicate<string> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.Filter(predicate);
    }

    [Fact]
    public static void Filter_SourceIsEmpty_ExpectDefault()
    {
        var source = default(FlatArray<RecordType>);

        var actual = source.Filter(Predicate);

        actual.VerifyInnerState(default, default);

        static bool Predicate(RecordType _)
            =>
            true;
    }

    [Fact]
    public static void Filter_SourceIsNotEmptyAndAllPredicatesReturnFalse_ExpectDefault()
    {
        var source = new[] { MinusFifteenIdRefType, ZeroIdRefType }.InitializeFlatArray();

        var actual = source.Filter(Predicate);

        actual.VerifyInnerState(default, default);

        static bool Predicate(RefType _)
            =>
            false;
    }

    [Fact]
    public static void Filter_SourceIsNotEmptyAndNotAllPredicatesReturnFalse_ExpectFilteredValues()
    {
        var mapper = new Dictionary<int, bool>
        {
            { MinusFifteen, false },
            { Zero, true },
            { MinusOne, true },
            { One, false },
            { PlusFifteen, true }
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(4);

        var actual = source.Filter(Predicate);
        var expectedItems = new[] { Zero, MinusOne, default, default };

        actual.VerifyInnerState(expectedItems, 2);

        bool Predicate(int item)
            =>
            mapper[item];
    }
}