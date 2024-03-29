using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Theory]
    [InlineData(-1, 1, true)]
    [InlineData(0, 2, false, true, true)]
    [InlineData(2, 5, null, false, null, true, false, true)]
    public void Enumerator_MoveNext_IndexIsLessThanLengthMinusOne_ExpectTrueAndNextIndex(
        int index, int length, params bool?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatListEnumerator(length, index);
        var actual = source.MoveNext();

        Assert.True(actual);
        source.VerifyFlatListEnumeratorState(length, copied, index + 1);
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, 1, SomeString)]
    [InlineData(1, 2, EmptyString, AnotherString, SomeString)]
    [InlineData(3, 4, SomeString, null, AnotherString, EmptyString)]
    public void Enumerator_MoveNext_IndexIsEqualToLengthMinusOne_ExpectFalseAndIndexIsEqualToLength(
        int index, int length, params string?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatListEnumerator(length, index);
        var actual = source.MoveNext();

        Assert.False(actual);
        source.VerifyFlatListEnumeratorState(length, copied, length);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1, One)]
    [InlineData(3, 2, PlusFifteen, Zero)]
    [InlineData(4, 4, MinusFifteen, One, PlusFifteen, null, MinusOne)]
    public void Enumerator_MoveNext_IndexIsEqualToLengthOrGreate_ExpectFalseAndIndexHasNotChanged(
        int index, int length, params int?[] items)
    {
        var copied = items.GetCopy();

        var source = items.InitializeFlatListEnumerator(length, index);
        var actual = source.MoveNext();

        Assert.False(actual);
        source.VerifyFlatListEnumeratorState(length, copied, index);
    }
}