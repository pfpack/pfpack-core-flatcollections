using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static IEnumerator<T> CreateFlatListEmptyEnumerator<T>()
        =>
        default(FlatArray<T>).AsEnumerable().GetEnumerator();
}