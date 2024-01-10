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
    public static void Exists_PredicateIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { PlusFifteen, MinusOne, int.MaxValue }.InitializeFlatArray();
        Func<int, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.Exists(predicate);
    }

    [Fact]
    public static void Exists_SourceIsEmpty_ExpectFalse()
    {
        var source = default(FlatArray<int>);
        var actual = source.Exists(Predicate);

        Assert.False(actual);

        static bool Predicate(int _)
            =>
            true;
    }

    [Fact]
    public static void Exists_SourceIsNotEmptyAndAllPredicatesReturnFalse_ExpectFalse()
    {
        var mapper = new Dictionary<RecordType, bool>
        {
            { PlusFifteenIdLowerSomeStringNameRecord, false },
            { ZeroIdNullNameRecord, false },
            { MinusFifteenIdNullNameRecord, false },
            { PlusFifteenIdSomeStringNameRecord, true }
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(3);
        var actual = source.Exists(Predicate);

        Assert.False(actual);

        bool Predicate(RecordType item)
            =>
            mapper[item];
    }

    [Fact]
    public static void Exists_SourceIsNotEmptyAndNotAllPredicatesReturnFalse_ExpectTrue()
    {
        var mapper = new Dictionary<RecordType, bool>
        {
            [ PlusFifteenIdLowerSomeStringNameRecord ] = false,
            [ ZeroIdNullNameRecord ] = true,
            [ MinusFifteenIdNullNameRecord ] = false
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(mapper.Count);
        var actual = source.Exists(Predicate);

        Assert.True(actual);

        bool Predicate(RecordType item)
            =>
            mapper[item];
    }
}