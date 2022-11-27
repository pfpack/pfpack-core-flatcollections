using System;
using System.Collections.Generic;
using Moq;
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
        var source = isDefault ? default : TestHelper.CreateFlatArrayByInnerConstructor(new[] { SomeString, EmptyString });

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

        var source = TestHelper.CreateFlatArrayByInnerConstructor(sourceItems);
        var mockAction = new Mock<IItemAction<int>>();

        source.ForEach(mockAction.Object.Invoke);

        mockAction.Verify(a => a.Invoke(PlusFifteen), Times.Once);
        mockAction.Verify(a => a.Invoke(One), Times.Once);
        mockAction.Verify(a => a.Invoke(Zero), Times.Once);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForEachWithIndex_ActionIsNull_ExpectArgumentNullException(
        bool isDefault)
    {
        var source = isDefault ? default : TestHelper.CreateFlatArrayByInnerConstructor(new bool?[] { true, null, false });
        
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

        var source = TestHelper.CreateFlatArrayByInnerConstructor(sourceItems);
        var mockAction = new Mock<IItemAction<string>>();

        source.ForEach(mockAction.Object.InvokeWithIndex);

        mockAction.Verify(a => a.InvokeWithIndex(0, "First"), Times.Once);
        mockAction.Verify(a => a.InvokeWithIndex(1, "Second"), Times.Once);
        mockAction.Verify(a => a.InvokeWithIndex(2, string.Empty), Times.Once);
        mockAction.Verify(a => a.InvokeWithIndex(3, "Fourth"), Times.Once);
        mockAction.Verify(a => a.InvokeWithIndex(4, string.Empty), Times.Once);
    }
}