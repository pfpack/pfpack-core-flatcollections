using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void GetEnumerator_SourceIsEmpty_ExpectInnerEnumeratorEmpty()
    {
        var source = (IEnumerable)TestHelper.CreateEmptyFlatList<decimal?>();

        var actual = source.GetEnumerator().GetType().Name;
        const string expected = "InnerEnumeratorEmpty";

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(3, null, false, true, true)]
    public void GetEnumerator_SourceIsNotEmpty_ExpectInnerEnumeratorCorrectState(
        int length, params bool?[] items)
    {
        var source = items.InitializeFlatList(length);
        
        var actual = source.GetEnumerator();
        var actualEnumerator = Assert.IsAssignableFrom<IEnumerator<bool?>>(actual);

        actualEnumerator.VerifyInnerFlatListEnumeratorState(items, length, -1);
    }
}