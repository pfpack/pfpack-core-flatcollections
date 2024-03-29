using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void AsEnumerable_SourceIsDefault_ExpectFlatListZeroLengthState()
    {
        var source = default(FlatArray<StructType?>);
        var actual = source.AsEnumerable();

        actual.VerifyFlatListState(Array.Empty<StructType?>(), 0);
    }

    [Theory]
    [InlineData(1, SomeString)]
    [InlineData(2, AnotherString, null, EmptyString, SomeString, TabString)]
    [InlineData(5, SomeString, EmptyString, LowerAnotherString, AnotherString, UpperSomeString)]
    public void AsEnumerable_SourceIsNotDefault_ExpectFlatListCorrectLengthState(
        int length, params string?[] items)
    {
        var coppied = items.GetCopy();

        var source = items.InitializeFlatArray(length);
        var actual = source.AsEnumerable();

        actual.VerifyFlatListState(coppied, length);
    }
}