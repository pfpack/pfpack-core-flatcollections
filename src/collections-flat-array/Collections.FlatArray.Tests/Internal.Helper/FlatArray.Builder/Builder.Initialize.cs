using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder InitializeFlatArrayBuilder<T>(this T[] items, int? length = null)
    {
        var source = default(FlatArray<T>.Builder);

        GetFlatArrayBuilderFieldSetter<T, T[]>("items").Invoke(source, items);
        GetFlatArrayBuilderFieldSetter<T, int>("length").Invoke(source, length ?? items.Length);

        return source;
    }

    private delegate void FlatArrayBuilderFieldSetter<T, TValue>(in FlatArray<T>.Builder source, TValue value);

    private static FlatArrayBuilderFieldSetter<T, TValue> GetFlatArrayBuilderFieldSetter<T, TValue>(string fieldName)
    {
        var type = typeof(FlatArray<T>.Builder);
        var method = type.CreateSetter(fieldName);

        var setter = method.CreateDelegate(typeof(FlatArrayBuilderFieldSetter<,>).MakeGenericType(typeof(T), typeof(TValue)));
        return (FlatArrayBuilderFieldSetter<T, TValue>)setter;
    }
}