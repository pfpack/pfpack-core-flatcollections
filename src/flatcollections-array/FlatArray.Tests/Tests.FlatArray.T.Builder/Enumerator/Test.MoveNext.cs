using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void Enumerator_MoveNext_SourceIsDefault_ExpectNullReferenceException()
    {
        var source = default(FlatArray<RefType>.Builder.Enumerator);

        _ = Assert.Throws<NullReferenceException>(() => _ = source.MoveNext());
    }

    [Theory]
    [InlineData(-1, 1, SomeString)]
    [InlineData(0, 2, WhiteSpaceString, AnotherString, null)]
    [InlineData(2, 5, SomeString, null, TabString, AnotherString, WhiteSpaceString)]
    public void Enumerator_MoveNext_IndexIsLessThanLengthMinusOne_ExpectTrueAndNextIndex(
        int index, int length, params string?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatArrayBuilder(length).InitializeEnumerator(index);
        var actual = source.MoveNext();

        Assert.True(actual);
        source.VerifyInnerState(length, copied, index + 1);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(6, 5, false, true, null, true, null, false, true)]
    public void Enumerator_MoveNext_IndexIsEqualToLengthOrGreate_ExpectFalseAndIndexHasNotChanged(
        int index, int length, params bool?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatArrayBuilder(length).InitializeEnumerator(index);
        var actual = source.MoveNext();

        Assert.False(actual);
        source.VerifyInnerState(length, copied, index);
    }
}