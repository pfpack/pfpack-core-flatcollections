using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T> actual, T[]? expectedItems, int expectedLength)
    {
        var actualLength = actual.GetStructFieldValue<int>("length");
        Assert.StrictEqual(expectedLength, actualLength);

        var actualItems = actual.GetFieldValue<T[]?>("items");
        var effectiveItems = actualItems is null
            ? null
            : new ReadOnlySpan<T>(actualItems, 0, actualLength).ToArray();

        Assert.Equal(expectedItems, effectiveItems);

        if (actualItems is not null)
        {
            var effectiveRest = new ReadOnlySpan<T>(
                actualItems,
                actualLength,
                actualItems.Length - effectiveItems!.Length)
                .ToArray();

            var actualRestIsDefault = effectiveRest.All(item => EqualityComparer<T>.Default.Equals(item, default));
            Assert.True(actualRestIsDefault);
        }
    }
}