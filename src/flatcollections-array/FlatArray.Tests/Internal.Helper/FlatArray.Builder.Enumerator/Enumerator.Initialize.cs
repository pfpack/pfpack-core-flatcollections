using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder.Enumerator InitializeEnumerator<T>(this FlatArray<T>.Builder builder, int index)
    {
        // Use a boxed default enumerator instance to modify its inner state next
        object enumerator = default(FlatArray<T>.Builder.Enumerator);

        enumerator.SetFieldValue("builder", builder);
        enumerator.SetFieldValue("index", index);

        return (FlatArray<T>.Builder.Enumerator)enumerator;
    }
}