using System;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder.Enumerator InitializeEnumerator<T>(this FlatArray<T>.Builder builder, int index)
    {
        var source = default(FlatArray<T>.Builder.Enumerator);
        var type = typeof(FlatArray<T>.Builder.Enumerator);

        type.CreateSetter<BuilderEnumeratorBuilderSetter<T>>("builder").Invoke(source, builder);
        type.CreateSetter<BuilderEnumeratorIndexSetter<T>>("index").Invoke(source, index);

        return source;
    }

    private delegate void BuilderEnumeratorBuilderSetter<T>(in FlatArray<T>.Builder.Enumerator source, FlatArray<T>.Builder builder);

    private delegate void BuilderEnumeratorIndexSetter<T>(in FlatArray<T>.Builder.Enumerator source, int index);
}