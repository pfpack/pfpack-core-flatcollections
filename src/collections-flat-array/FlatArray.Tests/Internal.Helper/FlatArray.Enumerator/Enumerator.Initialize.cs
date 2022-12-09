using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Enumerator InitializeFlatArrayEnumerator<T>(this T[] items, int index)
    {
        var source = default(FlatArray<T>.Enumerator);
        var type = typeof(FlatArray<T>.Enumerator);

        type.CreateSetter<EnumeratorItemsSetter<T>>("items").Invoke(source, new(items));
        type.CreateSetter<EnumeratorIndexSetter<T>>("index").Invoke(source, index);

        return source;
    }

    private delegate void EnumeratorItemsSetter<T>(in FlatArray<T>.Enumerator source, ReadOnlySpan<T> items);

    private delegate void EnumeratorIndexSetter<T>(in FlatArray<T>.Enumerator source, int index);
}