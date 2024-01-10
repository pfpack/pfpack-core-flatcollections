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
    public static void ExistsWithIndex_PredicateIsNull_ExpectArgumentNullException(
        bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new[] { SomeTextRecordStruct, AnotherTextRecordStruct }.InitializeFlatArray();
        Func<RecordStruct, int, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.Exists(predicate);
    }

    [Fact]
    public static void ExistsWithIndex_SourceIsEmpty_ExpectFalse()
    {
        var source = default(FlatArray<RecordStruct>);
        var actual = source.Exists(Predicate);

        Assert.False(actual);

        static bool Predicate(RecordStruct item, int _)
            =>
            true;
    }

    [Fact]
    public static void ExistsWithIndex_SourceIsNotEmptyAndAllPredicatesReturnFalse_ExpectDefault()
    {
        var mapper = new Dictionary<string, bool>
        {
            { AnotherString, false },
            { EmptyString, false },
            { SomeString, true }
        };

        var source = mapper.Keys.ToArray().InitializeFlatArray(2);
        var actual = source.Exists(Predicate);

        Assert.False(actual);

        bool Predicate(string item, int _)
            =>
            mapper[item];
    }

    [Fact]
    public static void ExistsWithIndex_SourceIsNotEmptyAndNotAllPredicatesReturnFalse_ExpectExistsedValues()
    {
        var mapper = new Dictionary<int, bool>
        {
            { One, false },
            { int.MinValue, false },
            { PlusFifteen, true },
            { Zero, true },
            { MinusOne, false },
            { int.MaxValue, true }
        };

        var sourceItems = mapper.Keys.ToArray();
        var source = sourceItems.InitializeFlatArray();

        var actual = source.Exists(Predicate);

        Assert.True(actual);

        bool Predicate(int item, int index)
        {
            Assert.Equal(sourceItems[index], item);
            return mapper[item];
        }
    }
}