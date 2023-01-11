using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderStaticTest
{
    [Theory]
    [InlineData(-5)]
    [InlineData(-1)]
    public void OfLength_LengthIsLessThanZero_ExpectArgumentOutOfRangeException(
        int length)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);
        Assert.Equal("length", ex.ParamName);

        void Test()
            =>
            _ = FlatArray.Builder.OfLength<RefType>(length);
    }

    [Fact]
    public void OfLength_LengthIsZero_ExpectDefaultState()
    {
        var actual = FlatArray.Builder.OfLength<RecordType?>(0);
        actual.VerifyInnerState(Array.Empty<RecordType?>(), default);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    public void OfLength_LengthIsMoreThanZero_ExpectDefaultValuesOfSourceLengthState(
        int length)
    {
        var actual = FlatArray.Builder.OfLength<RefType?>(length);
        var expectedItems = new RefType?[length];

        actual.VerifyInnerState(expectedItems, length);
    }
}