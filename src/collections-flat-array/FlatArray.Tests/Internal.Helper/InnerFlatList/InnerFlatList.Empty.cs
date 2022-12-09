using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static IList<T> CreateEmptyFlatList<T>()
        =>
        (IList<T>)default(FlatArray<T>).AsEnumerable();
}