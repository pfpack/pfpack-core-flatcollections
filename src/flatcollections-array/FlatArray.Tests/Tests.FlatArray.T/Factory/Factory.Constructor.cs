using System;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ConstructFromArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        int[]? source = null;
        var actual = new FlatArray<int>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromArray_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Array.Empty<RefType>();
        var actual = new FlatArray<RefType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(null, LowerAnotherString, EmptyString, WhiteSpaceString, UpperSomeString)]
    [InlineData("01", "02", "03", null, "05", "06", "07", "08", "09", "10", EmptyString, "12", "13", "14", "15", "16", "17")]
    public void ConstructFromArray_SourceIsNotEmpty_ExpectInnerStateIsSource(
        params string?[] source)
    {
        var coppied = source.GetCopy();
        var actual = new FlatArray<string?>(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromArray_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceArray = new[] { MinusFifteen, Zero, int.MaxValue };
        var actual = new FlatArray<int>(sourceArray);

        sourceArray[0] = PlusFifteen;
        var expectedItems = new[] { MinusFifteen, Zero, int.MaxValue };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ConstructFromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RefType>);
        var actual = new FlatArray<RefType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, null, SomeString, EmptyString, WhiteSpaceString)]
    public void ConstructFromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = new FlatArray<string?>(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = new FlatArray<StructType?>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType>? source = default(FlatArray<RecordType>);
        var actual = new FlatArray<RecordType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<bool?>? source = new bool?[] { false, null, true }.InitializeFlatArray();

        var actual = new FlatArray<bool?>(source);
        var expectedItems = new bool?[] { false, null, true };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void ConstructFromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<long?>);
        var actual = new FlatArray<long?>(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(LowerSomeString, null, AnotherString)]
    public void ConstructFromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.ToImmutableArray();
        var actual = new FlatArray<string?>(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void ConstructFromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RecordType>? source = null;
        var actual = new FlatArray<RecordType>(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void ConstructFromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = new ImmutableArray<RefType?>();
        var actual = new FlatArray<RefType?>(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(null, MinusFifteen, Zero)]
    public void ConstructFromNullableImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params int?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        ImmutableArray<int?>? source = sourceItems.ToImmutableArray();
        var actual = new FlatArray<int?>(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }
}