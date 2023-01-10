using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void GetEnumerator_SourceIsDefault_ExpectEnumeratorWithDefaultState()
    {
        var source = new FlatArray<StructType>.Builder();
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(default, Array.Empty<StructType>(), -1);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(4, AnotherString, UpperSomeString, EmptyString, SomeString, null, WhiteSpaceString)]
    public void GetEnumerator_SourceIsNotDefault_ExpectEnumeratorWithCorrectState(
        int length, params string?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatArrayBuilder(length);
        var actual = source.GetEnumerator();

        actual.VerifyInnerState(length, copied, -1);
    }
}