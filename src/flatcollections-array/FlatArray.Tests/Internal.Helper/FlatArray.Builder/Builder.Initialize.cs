using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder InitializeFlatArrayBuilder<T>(this T[] items, int? length = null)
    {
        var builder = new FlatArray<T>.Builder();

        builder.SetFieldValue("length", length ?? items.Length);
        builder.SetFieldValue("items", items);

        return builder;
    }
}