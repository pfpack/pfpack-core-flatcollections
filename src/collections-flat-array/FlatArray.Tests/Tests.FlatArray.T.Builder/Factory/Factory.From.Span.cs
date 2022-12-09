using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<RefType?>);
        var actual = FlatArray<RefType?>.Builder.From(source);

        actual.VerifyInnerState(default, default);
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

        actual.VerifyInnerState(default, default);
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
    public void FromSpan_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var source = new[] { SomeString, null, EmptyString, UpperSomeString, AnotherString }.AsSpan();
        var actual = FlatArray<string?>.Builder.From(source);

        source[3] = TabString;

        var expectedItems = new[] { SomeString, null, EmptyString, UpperSomeString, AnotherString };
        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}