using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectArrayStateIsDefault()
    {
        var source = new FlatArray<string>.Builder();
        var actual = source.MoveToFlatArray();

        actual.VerifyInnerState(default, default);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectBuilderStateIsDefault()
    {
        var source = new FlatArray<RefType>.Builder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState(Array.Empty<RefType>(), default);
    }

    [Theory]
    [MemberData(nameof(MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderState_CaseSource))]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderState(
        int length,
        RefType[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(length);
        var actual = source.MoveToFlatArray();
        actual.VerifyInnerState_TheSameAssert(sourceItems, length);
    }

    [Theory]
    [MemberData(nameof(MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderState_CaseSource))]
    public void MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderState(
        int length,
        RefType[] sourceItems,
        RefType[] expectedItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(length);
        var actual = source.MoveToFlatArray();
        actual.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectBuilderStateIsDefault()
    {
        var source = new[] { MinusFifteen, Zero, PlusFifteen, int.MaxValue, One }.InitializeFlatArrayBuilder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState(Array.Empty<int>(), default);
    }

    public static IEnumerable<object[]> MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderState_CaseSource()
    {
        yield return new object[]
        {
            2,
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType }
        };
        yield return new object[]
        {
            2,
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, null }
        };
        yield return new object[]
        {
            3,
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType }
        };
        yield return new object[]
        {
            3,
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, null }
        };
        yield return new object[]
        {
            3,
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, null, null }
        };
    }


    public static IEnumerable<object[]> MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderState_CaseSource()
    {
        yield return new object[]
        {
            2,
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, null, null },
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType }
        };
        yield return new object[]
        {
            2,
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType, null, null, null },
            new[] { PlusFifteenIdRefType, MinusFifteenIdRefType }
        };
        yield return new object[]
        {
            3,
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, null, null, null },
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType }
        };
        yield return new object[]
        {
            3,
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType, null, null, null, null },
            new[] { PlusFifteenIdRefType, null, MinusFifteenIdRefType }
        };
    }
}
