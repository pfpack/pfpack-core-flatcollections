using System.Collections.Generic;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class TestExtensions
{
    internal static T[]? GetInnerItems<T>(this FlatArray<T> array)
        =>
        (T[]?)typeof(FlatArray<T>).GetInnerFieldInfoOrThrow("items").GetValue(array);
}