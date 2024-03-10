using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<RefType>);
        var actual = FlatArray<RefType>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Theory]
    [InlineData(SomeString, AnotherString)]
    [InlineData(LowerSomeString, null, SomeString, EmptyString, WhiteSpaceString)]
    public void FromFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.InitializeFlatArray();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        var source = default(FlatArray<StructType?>?);
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        FlatArray<RecordType>? source = default(FlatArray<RecordType>);
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void FromNullableFlatArray_SourceIsNotDefault_ExpectInnerStateIsSourceArray()
    {
        FlatArray<bool?>? source = new bool?[] { false, null, true }.InitializeFlatArray();

        var actual = FlatArray<bool?>.From(source);
        var expectedItems = new bool?[] { false, null, true };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}