using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;
using static PrimeFuncPack.Collections.Tests.FlatArrayFlatListTestSource;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void CopyTo_SourceIsEmptyAndArrayIsNull_ExpectArgumentNullException(
        int arrayIndex)
    {
        var source = TestHelper.CreateEmptyFlatList<RecordStruct>();
        _ = Assert.Throws<ArgumentNullException>(Test);

        void Test()
            =>
            source.CopyTo(null!, arrayIndex);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0, SomeString, null)]
    [InlineData(1, EmptyString, SomeString)]
    [InlineData(3, EmptyString, SomeString, null)]
    public void CopyTo_SourceIsEmptyAndArrayIndexIsNotLessThanZero_ExpectArrayHasNotChanged(
        int arrayIndex, params string?[] array)
    {
        var source = TestHelper.CreateEmptyFlatList<string?>();
        var coppied = array.GetCopy();

        source.CopyTo(array, arrayIndex);
        Assert.Equal(coppied, array);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5, SomeString, AnotherString)]
    public void CopyTo_SourceIsEmptyAndArrayIndexIsLessThanZero_ExpectArgumentOutOfRangeException(
        int arrayIndex, params string?[] array)
    {
        var source = TestHelper.CreateEmptyFlatList<string?>();
        _ = Assert.Throws<ArgumentOutOfRangeException>(Test);

        void Test()
            =>
            source.CopyTo(array, arrayIndex);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4, AnotherString, EmptyString, SomeString)]
    public void CopyTo_SourceIsEmptyAndArrayIndexIsGreaterThanArrayLength_ExpectArgumentException(
        int arrayIndex, params string?[] array)
    {
        var source = TestHelper.CreateEmptyFlatList<string?>();
        _ = Assert.Throws<ArgumentException>(Test);

        void Test()
            =>
            source.CopyTo(array, arrayIndex);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void CopyTo_SourceIsNotEmptyAndArrayIsNull_ExpectArgumentNullException(
        int arrayIndex)
    {
        var source = new[] { PlusFifteenIdRefType }.InitializeFlatList();
        _ = Assert.Throws<ArgumentNullException>(Test);

        void Test()
            =>
            source.CopyTo(null!, arrayIndex);
    }

    [Theory]
    [MemberData(nameof(GetRecordTypeCopyToInRangeTestData), MemberType = typeof(FlatArrayFlatListTestSource))]
    public void CopyTo_SourceIsNotEmptyAndArrayIndexIsInRange_ExpectCorrectArray(
        IList<RecordType?> source, RecordType?[] array, int arrayIndex, RecordType?[] expected)
    {
        source.CopyTo(array, arrayIndex);
        Assert.Equal(expected, array);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5, false, true)]
    public void CopyTo_SourceIsNotEmptyAndArrayIndexIsLessThanZero_ExpectArgumentOutOfRangeException(
        int arrayIndex, params bool[] array)
    {
        var source = new[] { true }.InitializeFlatList();
        _ = Assert.Throws<ArgumentOutOfRangeException>(Test);

        void Test()
            =>
            source.CopyTo(array, arrayIndex);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4, null, PlusFifteen, MinusFifteen, Zero)]
    [InlineData(5, null, PlusFifteen, MinusFifteen, Zero)]
    public void CopyTo_SourceIsNotEmptyAndArrayLengthIsNotEnough_ExpectArgumentException(
        int arrayIndex, params int?[] array)
    {
        var source = new int?[] { One }.InitializeFlatList();
        _ = Assert.Throws<ArgumentException>(Test);

        void Test()
            =>
            source.CopyTo(array, arrayIndex);
    }
}