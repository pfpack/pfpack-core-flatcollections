using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder InitializeFlatArrayBuilder<T>(this T[] items, int? length = null)
    {
        var source = default(FlatArray<T>.Builder);
        var type = typeof(FlatArray<T>.Builder);

        type.CreateSetter<BuilderFieldSetter<T, T[]>>("items").Invoke(source, items);
        type.CreateSetter<BuilderFieldSetter<T, int>>("length").Invoke(source, length ?? items.Length);

        return source;
    }

    private delegate void BuilderFieldSetter<T, TValue>(in FlatArray<T>.Builder source, TValue value);
}