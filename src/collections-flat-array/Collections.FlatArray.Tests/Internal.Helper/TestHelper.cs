using System;
using System.Collections.Generic;
using System.Reflection;

namespace PrimeFuncPack.Collections.Tests;

internal static partial class TestHelper
{
    private static int GetInnerLength<T>(this FlatArray<T> array)
        =>
        GetFlatArrayLengthFieldInfo<T>().GetValue(array) switch
        {
            int length => length,
            var unexpected => throw new InvalidOperationException($"An unexpected inner length value: {unexpected}")
        };

    private static T[]? GetInnerItems<T>(this FlatArray<T> array)
        =>
        (T[]?)GetFlatArrayItemsFieldInfo<T>().GetValue(array);

    private static FieldInfo GetFlatArrayLengthFieldInfo<T>()
        =>
        GetInnerFieldInfoOrThrow<T>("length");

    private static FieldInfo GetFlatArrayItemsFieldInfo<T>()
        =>
        GetInnerFieldInfoOrThrow<T>("items");

    private static FieldInfo GetInnerFieldInfoOrThrow<T>(string fieldName)
        =>
        typeof(FlatArray<T>).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException($"An inner field '{fieldName}' of the FlatArray<T> type was not found");
}