using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RefType>);
        var actual = FlatArray<RefType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType>(), default);
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, null, SomeString, EmptyString, WhiteSpaceString)]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = FlatArray<string?>.Builder.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = FlatArray<StructType?>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType?>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType>? source = default(FlatArray<RecordType>);
        var actual = FlatArray<RecordType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RecordType>(), default);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<bool?>? source = new bool?[] { false, null, true }.InitializeFlatArray(2);

        var actual = FlatArray<bool?>.Builder.From(source);
        var expectedItems = new bool?[] { false, null };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}