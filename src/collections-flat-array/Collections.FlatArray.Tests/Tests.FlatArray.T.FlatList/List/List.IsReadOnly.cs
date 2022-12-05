using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void IsReadOnly_SourceArrayIsDefault_ExpectTrue()
    {
        var source = TestHelper.CreateEmptyFlatList<RefType>();
        var actual = source.IsReadOnly;

        Assert.True(actual);
    }

    [Fact]
    public void IsReadOnly_SourceArrayIsNotDefault_ExpectTrue()
    {
        var source = new[] { SomeTextRecordStruct, AnotherTextRecordStruct }.InitializeFlatList();
        var actual = source.IsReadOnly;

        Assert.True(actual);
    }
}