using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Enumerator InitializeFlatArrayEnumerator<T>(this T[] items, int index)
    {
        var source = default(FlatArray<T>.Enumerator);

        GetFlatArrayEnumeratorItemsSetter<T>().Invoke(source, new(items));
        GetFlatArrayEnumeratorIndexSetter<T>().Invoke(source, index);

        return source;
    }

    private delegate void FlatArrayEnumeratorItemsSetter<T>(in FlatArray<T>.Enumerator source, ReadOnlySpan<T> items);

    private delegate void FlatArrayEnumeratorIndexSetter<T>(in FlatArray<T>.Enumerator source, int index);

    private static FlatArrayEnumeratorItemsSetter<T> GetFlatArrayEnumeratorItemsSetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var method = type.CreateSetter("items");

        var setter = method.CreateDelegate(typeof(FlatArrayEnumeratorItemsSetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayEnumeratorItemsSetter<T>)setter;
    }

    private static FlatArrayEnumeratorIndexSetter<T> GetFlatArrayEnumeratorIndexSetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var method = type.CreateSetter("index");

        var setter = method.CreateDelegate(typeof(FlatArrayEnumeratorIndexSetter<>).MakeGenericType(typeof(T)));
        return (FlatArrayEnumeratorIndexSetter<T>)setter;
    }
}