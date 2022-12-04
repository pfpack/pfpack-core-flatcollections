using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void Fill_SourceIsDefault_ExpectDefaultState()
    {
        var source = default(FlatArray<RefType>.Builder);
        source.Fill();

        source.VerifyInnerState(default, default);
    }

    [Fact]
    public void Fill_SourceIsNotDefault_ExpectStateItemsAreDefault()
    {
        const int length = 2;
        var source = new[] { PlusFifteenIdSomeStringNameRecord, null, ZeroIdNullNameRecord }.InitializeFlatArrayBuilder(length);

        source.Fill();

        var expectedItems = new[] { null, null, ZeroIdNullNameRecord };
        source.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void FillValue_SourceIsDefault_ExpectDefaultState()
    {
        var source = default(FlatArray<StructType?>.Builder);
        source.Fill(SomeTextStructType);

        source.VerifyInnerState(default, default);
    }

    [Fact]
    public void FillValue_SourceIsNotDefault_ExpectStateItemsIsValue()
    {
        const int length = 3;
        var source = new[] { SomeString, EmptyString, null, AnotherString }.InitializeFlatArrayBuilder(length);

        source.Fill(UpperSomeString);
        var expectedItems = new[] { UpperSomeString, UpperSomeString, UpperSomeString, AnotherString };

        source.VerifyInnerState(expectedItems, length);
    }
}