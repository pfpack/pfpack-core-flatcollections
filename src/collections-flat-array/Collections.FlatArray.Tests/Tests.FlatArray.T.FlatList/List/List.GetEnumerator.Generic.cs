using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void GetEnumeratorGeneric_SourceIsEmpty_ExpectTypeIsInnerEnumeratorCorrectState()
    {
        var source = TestHelper.CreateEmptyFlatList<RecordType>();
        var actual = source.GetEnumerator();

        actual.VerifyInnerFlatListEnumeratorState(Array.Empty<RecordType>(), 0, -1);
    }

    [Theory]
    [InlineData(1, EmptyString)]
    [InlineData(2, SomeString, AnotherString, TabString, EmptyString)]
    public void GetEnumeratorGeneric_SourceIsNotEmpty_ExpectInnerEnumeratorCorrectState(
        int length, params string?[] items)
    {
        var source = items.InitializeFlatList(length);
        var actual = source.GetEnumerator();

        actual.VerifyInnerFlatListEnumeratorState(items, length, -1);
    }
}