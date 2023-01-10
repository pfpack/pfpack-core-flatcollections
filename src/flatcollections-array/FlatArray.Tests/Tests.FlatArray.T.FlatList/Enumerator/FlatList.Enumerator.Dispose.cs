using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void Enumerator_Dispose_ExpectStateHasNotChanged()
    {
        var sourceItems = new RecordStruct?[] { SomeTextRecordStruct, AnotherTextRecordStruct, null, UpperSomeTextRecordStruct };
        var source = sourceItems.InitializeFlatListEnumerator(3, 1);

        source.Dispose();

        var expectedItems = new RecordStruct?[] { SomeTextRecordStruct, AnotherTextRecordStruct, null, UpperSomeTextRecordStruct };
        source.VerifyFlatListEnumeratorState(3, expectedItems, 1);
    }
}