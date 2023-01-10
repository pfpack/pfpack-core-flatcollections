using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void GetEnumerator_SourceIsEmpty_ExpectEnumeratorEmptyState()
    {
        var source = (IEnumerable)TestHelper.CreateEmptyFlatList<decimal?>();

        var actual = source.GetEnumerator();
        var actualEnumerator = Assert.IsAssignableFrom<IEnumerator<decimal?>>(actual);

        actualEnumerator.VerifyFlatListEnumeratorState(0, Array.Empty<decimal?>(), -1);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(3, null, false, true, true)]
    public void GetEnumerator_SourceIsNotEmpty_ExpectEnumeratorCorrectState(
        int length, params bool?[] items)
    {
        var source = (IEnumerable)items.InitializeFlatList(length);
        
        var actual = source.GetEnumerator();
        var actualEnumerator = Assert.IsAssignableFrom<IEnumerator<bool?>>(actual);

        actualEnumerator.VerifyFlatListEnumeratorState(length, items, -1);
    }
}