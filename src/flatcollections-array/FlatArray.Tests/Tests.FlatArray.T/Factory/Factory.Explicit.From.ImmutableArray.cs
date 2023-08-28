using System;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<long?>);
        var actual = FlatArray<long?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData(LowerSomeString, null, AnotherString)]
    public void FromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params string?[] sourceArray)
    {
        var coppied = sourceArray.GetCopy();

        var source = sourceArray.ToImmutableArray();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsNull_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RecordType>? source = null;
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void FromNullableImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        ImmutableArray<RefType?>? source = new ImmutableArray<RefType?>();
        var actual = FlatArray<RefType?>.From(source);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(PlusFifteen)]
    [InlineData(null, MinusFifteen, Zero)]
    public void FromNullableImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems(
        params int?[] sourceItems)
    {
        var coppied = sourceItems.GetCopy();

        ImmutableArray<int?>? source = sourceItems.ToImmutableArray();
        var actual = FlatArray<int?>.From(source);

        actual.VerifyInnerState(coppied, coppied.Length);
    }
}