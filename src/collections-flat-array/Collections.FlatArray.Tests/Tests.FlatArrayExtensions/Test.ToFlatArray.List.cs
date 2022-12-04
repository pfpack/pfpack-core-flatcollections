using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void ToFlatArray_SourceIsNullList_ExpectInnerStateIsDefault()
    {
        List<RefType?>? source = null;
        var actual = source.ToFlatArray();

        actual.VerifyDefaultState();
    }

    [Fact]
    public void ToFlatArray_SourceIsEmptyList_ExpectInnerStateIsDefault()
    {
        var source = new List<long>();
        var actual = source.ToFlatArray();

        actual.VerifyDefaultState();
    }

    [Fact]
    public void ToFlatArray_SourceIsNotEmptyList_ExpectInnerStateAreSourceItems()
    {
        var source = new List<string> { SomeString, AnotherString };
        var actual = source.ToFlatArray();

        const int expectedLength = 2;
        var expectedItems = new[] { SomeString, AnotherString };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    [Fact]
    public void ToFlatArray_ThanModifySourceList_ExpectInnerStateHasNotChanged()
    {
        var sourceList = new List<object?> { SomeString, null, MinusFifteenIdRefType, Zero };
        var actual = sourceList.ToFlatArray();

        sourceList[2] = ZeroIdNullNameRecord;
        sourceList.Add(long.MaxValue);

        const int expectedLength = 4;
        var expectedItems = new object?[] { SomeString, null, MinusFifteenIdRefType, Zero };

        actual.VerifyInnerState(expectedItems, expectedLength);
    }
}