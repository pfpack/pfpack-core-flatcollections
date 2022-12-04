using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayEnumeratorTest
{
    [Fact]
    public void Current_SourceIsDefault_ExpectArgumentOutOfRangeException()
    {
        var source = default(FlatArray<StructType>.Enumerator);
        
        try
        {
            _ = source.Current;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        Assert.Fail("An expected IndexOutOfRangeException was not thrown");
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true, null, false)]
    [InlineData(4, false, true, true, null, false)]
    public void Current_IndexIsInRange_ExpectItemByIndex(
        int index, params bool?[] sourceItems)
    {
        var coppiedItems = sourceItems.GetCopy();
        var source = sourceItems.InitializeFlatArrayEnumerator(index);

        var actual = source.Current;
        var expected = coppiedItems[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1, SomeString)]
    [InlineData(5, AnotherString, EmptyString, null)]
    [InlineData(-1, TabString, SomeString)]
    public void Current_IndexIsNotInRange_ExpectIndexOutOfRangeException(
        int index, params string?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayEnumerator(index);

        try
        {
            _ = source.Current;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        Assert.Fail("An expected IndexOutOfRangeException was not thrown");
    }
}