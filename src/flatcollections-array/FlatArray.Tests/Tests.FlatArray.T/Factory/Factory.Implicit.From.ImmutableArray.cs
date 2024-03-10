using System;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitFromImmutableArray_SourceIsDefault_ExpectInnerStateIsDefault()
    {
        var source = default(ImmutableArray<RefType>);
        FlatArray<RefType> actual = source;

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void ImplicitFromImmutableArray_SourceIsNotDefault_ExpectInnerStateAreSourceItems()
    {
        var sourceBuilder = ImmutableArray.CreateBuilder<string?>(5);

        sourceBuilder.Add("One");
        sourceBuilder.Add("Two");
        sourceBuilder.Add("Three");
        sourceBuilder.Add("Four");
        sourceBuilder.Add(null);

        FlatArray<string?> actual = sourceBuilder.ToImmutable();

        var expectedItems = new[]
        {
            "One", "Two", "Three", "Four", null
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}