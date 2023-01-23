using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<RefType?>);
        var actual = FlatArray<RefType?>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<RefType?>(), default);
    }

    [Fact]
    public void FromReadOnlySpan_SourceIsNotDefault_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[]
        {
            SomeTextRecordStruct, UpperAnotherTextRecordStruct, default
        };

        var source = new ReadOnlySpan<RecordStruct>(sourceItems);
        var actual = FlatArray<RecordStruct>.Builder.From(source);

        var expectedItems = new[]
        {
            SomeTextRecordStruct, UpperAnotherTextRecordStruct, default
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromSpan_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(Span<StructType>);
        var actual = FlatArray<StructType>.Builder.From(source);

        actual.VerifyInnerState(Array.Empty<StructType>(), default);
    }

    [Fact]
    public void FromSpan_SourceIsNotDefault_ExpectInnerStateAreSourceItems()
    {
        var source = new[] { MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord }.AsSpan();
        var actual = FlatArray<RecordType>.Builder.From(source);

        var expectedItems = new[]
        {
            MinusFifteenIdNullNameRecord, ZeroIdNullNameRecord
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromSpan_ThenModifySource_ExpectInnerStateHasNotChanged()
    {
        var source = new[] { SomeString, null, EmptyString, UpperSomeString, AnotherString }.AsSpan();
        var actual = FlatArray<string?>.Builder.From(source);

        source[3] = TabString;

        var expectedItems = new[] { SomeString, null, EmptyString, UpperSomeString, AnotherString };
        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}