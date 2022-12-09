using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void GetEnumerator_SourceIsDefault_ExpectEnumeratorWithDefaultState()
    {
        var source = default(FlatArray<StructType>.Builder);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(default, default, -1);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(4, AnotherString, UpperSomeString, EmptyString, SomeString, null, WhiteSpaceString)]
    public void GetEnumerator_SourceIsNotDefault_ExpectEnumeratorWithCorrectState(
        int length, params string?[] items)
    {
        var coppied = items.GetCopy();

        var source = items.InitializeFlatArrayBuilder(length);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(coppied, length, -1);
    }
}