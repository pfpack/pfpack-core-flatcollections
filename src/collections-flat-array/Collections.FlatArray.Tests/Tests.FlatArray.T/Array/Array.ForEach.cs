using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class FlatArrayTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForEach_ActionIsNull_ExpectArgumentNullException(
        bool isDefault)
    {
        var source = isDefault ? default : TestHelper.Initialize(new[] { SomeString, EmptyString });

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

        var expectedQueue = new Queue<int>(sourceItems);

        var source = TestHelper.Initialize(sourceItems);
        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(int actual)
        {
            var expected = expectedQueue.Dequeue();
            Assert.StrictEqual(expected, actual);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForEachWithIndex_ActionIsNull_ExpectArgumentNullException(
        bool isDefault)
    {
        var source = isDefault ? default : TestHelper.Initialize(new bool?[] { true, null, false });
        
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

        var expectedSequence = new KeyValuePair<int, string>[]
        {
            new(0, "First"),
            new(1, "Second"),
            new(2, EmptyString),
            new(3, "Fourth"),
            new(4, EmptyString)
        };

        var expectedQueue = new Queue<KeyValuePair<int, string>>(expectedSequence);

        var source = TestHelper.Initialize(sourceItems);
        source.ForEach(Invoke);

        Assert.Empty(expectedQueue);

        void Invoke(int index, string item)
        {
            var expected = expectedQueue.Dequeue();

            Assert.StrictEqual(expected.Key, index);
            Assert.Equal(expected.Value, item);
        }
    }
}