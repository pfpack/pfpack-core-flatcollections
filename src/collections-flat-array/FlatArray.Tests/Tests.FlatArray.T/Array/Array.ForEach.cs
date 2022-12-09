using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForEach_ActionIsNull_ExpectArgumentNullException(
        bool isDefault)
    {
        var source = isDefault ? default : new[] { SomeString, EmptyString }.InitializeFlatArray();

        Action<string> action = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("action", ex.ParamName);

        void Test()
            =>
            source.ForEach(action);
    }

    [Fact]
    public void ForEach_SourceIsDefault_ExpectActionCalledNever()
    {
        var source = default(FlatArray<string>);
        source.ForEach(Invoke);

        static void Invoke(string item)
            =>
            Assert.Fail($"The action for an item '{item}' must not be invoked");
    }

    [Fact]
    public void ForEach_SourceIsNotDefault_ExpectActionCalledForEachItem()
    {
        var sourceItems = new[]
        {
            PlusFifteen, One, Zero
        };

        var source = sourceItems.InitializeFlatArray();

        var expectedQueue = new Queue<int>(sourceItems);
        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(int actual)
        {
            var expected = expectedQueue.Dequeue();
            Assert.StrictEqual(expected, actual);
        }
    }

    [Fact]
    public void ForEach_InnerLengthIsLessThanItemsLength_ExpectActionCalledLengthTimes()
    {
        var sourceItems = new[]
        {
            SomeString, null, AnotherString, EmptyString
        };

        var source = sourceItems.InitializeFlatArray(3);

        var expectedQueue = new Queue<string?>();

        expectedQueue.Enqueue(SomeString);
        expectedQueue.Enqueue(null);
        expectedQueue.Enqueue(AnotherString);

        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(string? actual)
        {
            var expected = expectedQueue.Dequeue();
            Assert.Equal(expected, actual);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForEachWithIndex_ActionIsNull_ExpectArgumentNullException(
        bool isDefault)
    {
        var source = isDefault ? default : new bool?[] { true, null, false }.InitializeFlatArray();
        
        Action<int, bool?> action = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("action", ex.ParamName);

        void Test()
            =>
            source.ForEach(action);
    }

    [Fact]
    public void ForEachWithIndex_SourceIsDefault_ExpectActionCalledNever()
    {
        var source = default(FlatArray<RecordStruct>);
        source.ForEach(Invoke);

        static void Invoke(int index, RecordStruct item)
            =>
            Assert.Fail($"The action for an item '{item}' by the index '{index}' must not be invoked");
    }

    [Fact]
    public void ForEachWithIndex_SourceIsNotDefault_ExpectActionCalledForEachItem()
    {
        var sourceItems = new[]
        {
            "First", "Second", EmptyString, "Fourth", EmptyString
        };

        var source = sourceItems.InitializeFlatArray();

        var expectedSequence = new KeyValuePair<int, string>[]
        {
            new(0, "First"),
            new(1, "Second"),
            new(2, EmptyString),
            new(3, "Fourth"),
            new(4, EmptyString)
        };

        var expectedQueue = new Queue<KeyValuePair<int, string>>(expectedSequence);
        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(int index, string item)
        {
            var expected = expectedQueue.Dequeue();

            Assert.StrictEqual(expected.Key, index);
            Assert.Equal(expected.Value, item);
        }
    }

    [Fact]
    public void ForEachWithIndex_InnerLengthIsLessThanItemsLength_ExpectActionCalledLengthTimes()
    {
        var sourceItems = new[]
        {
            MinusFifteen, One, int.MinValue, PlusFifteen, MinusOne, Zero, int.MaxValue
        };

        var source = sourceItems.InitializeFlatArray(4);

        var expectedQueue = new Queue<KeyValuePair<int, int>>();

        expectedQueue.Enqueue(new(0, MinusFifteen));
        expectedQueue.Enqueue(new(1, One));
        expectedQueue.Enqueue(new(2, int.MinValue));
        expectedQueue.Enqueue(new(3, PlusFifteen));

        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(int index, int item)
        {
            var expected = expectedQueue.Dequeue();

            Assert.StrictEqual(expected.Key, index);
            Assert.Equal(expected.Value, item);
        }
    }
}