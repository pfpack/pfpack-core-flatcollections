using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderStaticTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<RefType>);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var sourceItems = new[] { PlusFifteenIdLowerSomeStringNameRecord, ZeroIdNullNameRecord, null, MinusFifteenIdNullNameRecord };
        var source = new ReadOnlySpan<RecordType?>(sourceItems);

        var actual = FlatArray.Builder.From(source);
        var expectedItems = new[] { PlusFifteenIdLowerSomeStringNameRecord, ZeroIdNullNameRecord, null, MinusFifteenIdNullNameRecord };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(Span<StructType?>);
        var actual = FlatArray.Builder.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        var source = new[] { SomeString, AnotherString, EmptyString }.AsSpan();

        var actual = FlatArray.Builder.From(source);
        var expectedItems = new[] { SomeString, AnotherString, EmptyString };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }

    [Fact]
    public void FromSpan_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType
        };

        var source = sourceItems.AsSpan();
        var actual = FlatArray.Builder.From(source);

        source[0] = new();

        var expectedItems = new[]
        {
            PlusFifteenIdRefType, null, MinusFifteenIdRefType, ZeroIdRefType
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}