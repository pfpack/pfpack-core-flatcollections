using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.Core.Tests.TestData;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void FromIEnumerable_IEnumerable_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = Enumerable.Empty<RefType?>();
        var actual = FlatArray<RefType?>.From(source);

        actual.VerifyInnerState_Default();
    }

    [Theory]
    [MemberData(nameof(ReadingCollectionsTestSource.EnumerateStringNonEmptyCases), MemberType = typeof(ReadingCollectionsTestSource))]
    public void FromIEnumerable_IEnumerable_SourceIsNotEmpty_ExpectInnerStateCorrespondsToSource(
        string?[] sourceItems, string?[] expectedItems)
    {
        var source = GetSource();
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(expectedItems, sourceItems.Length);

        IEnumerable<string?> GetSource()
        {
            foreach (var item in sourceItems)
            {
                yield return item;
            }
        }
    }
}