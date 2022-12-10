using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Enumerator InitializeFlatArrayEnumerator<T>(this T[] items, int length, int index)
    {
        var source = default(FlatArray<T>.Enumerator);
        var type = typeof(FlatArray<T>.Enumerator);

        type.CreateSetter<EnumeratorLengthSetter<T>>("length").Invoke(source, length);
        type.CreateSetter<EnumeratorItemsSetter<T>>("items").Invoke(source, items);
        type.CreateSetter<EnumeratorIndexSetter<T>>("index").Invoke(source, index);

        return source;
    }

    private delegate void EnumeratorLengthSetter<T>(in FlatArray<T>.Enumerator source, int length);

    private delegate void EnumeratorItemsSetter<T>(in FlatArray<T>.Enumerator source, T[] items);

    private delegate void EnumeratorIndexSetter<T>(in FlatArray<T>.Enumerator source, int index);
}