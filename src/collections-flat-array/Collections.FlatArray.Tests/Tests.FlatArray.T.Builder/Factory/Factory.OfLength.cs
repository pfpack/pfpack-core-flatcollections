using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayBuilderTest
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
            _ = FlatArray<RefType>.Builder.OfLength(length);
    }

    [Fact]
    public void OfLength_LengthIsZero_ExpectDefaultState()
    {
        var actual = FlatArray<RecordType?>.Builder.OfLength(0);
        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    public void OfLength_LengthIsMoreThanZeroAndLessThanMaxArrayLength_ExpectDefaultValuesOfSourceLengthState(
        int length)
    {
        var actual = FlatArray<RefType?>.Builder.OfLength(length);
        var expectedItems = new RefType?[length];

        actual.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void OfLength_LengthIsMaxArrayLength_ExpectInnerLengthIsMaxArrayLength()
    {
        var length = Array.MaxLength;
        var actual = FlatArray<RefType?>.Builder.OfLength(length);

        actual.VerifyInnerLength(length, length);
    }

    [Fact]
    public void OfLength_LengthIsGreaterThanMaxArrayLength_ExpectArgumentOutOfRangeException()
    {
        var length = Array.MaxLength + 1;
        _ = Assert.Throws<OutOfMemoryException>(Test);

        void Test()
            =>
            _ = FlatArray<RecordType?>.Builder.OfLength(length);
    }
}