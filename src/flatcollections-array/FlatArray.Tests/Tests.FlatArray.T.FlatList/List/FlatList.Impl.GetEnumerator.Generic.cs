using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void GetEnumeratorGeneric_SourceIsEmpty_ExpectTypeIsEnumeratorCorrectState()
    {
        var source = TestHelper.CreateEmptyFlatList<RecordType>();
        var actual = source.GetEnumerator();

        actual.VerifyFlatListEnumeratorState(Array.Empty<RecordType>(), 0, -1);
    }

    [Theory]
    [InlineData(1, EmptyString)]
    [InlineData(2, SomeString, AnotherString, TabString, EmptyString)]
    public void GetEnumeratorGeneric_SourceIsNotEmpty_ExpectEnumeratorCorrectState(
        int length, params string?[] items)
    {
        var source = items.InitializeFlatList(length);
        var actual = source.GetEnumerator();

        actual.VerifyFlatListEnumeratorState(items, length, -1);
    }
}