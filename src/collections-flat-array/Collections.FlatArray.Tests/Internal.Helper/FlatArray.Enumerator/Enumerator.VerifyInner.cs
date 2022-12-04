using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static void VerifyInnerState<T>(this FlatArray<T>.Enumerator actual, T[] expectedItems, int expectedIndex)
    {
        var actualItems = GetFlatArrayEnumeratorItemsGetter<T>().Invoke(actual);
        Assert.Equal(expectedItems, actualItems.ToArray());

        var actualIndex = GetFlatArrayEnumeratorIndexGetter<T>().Invoke(actual);
        Assert.Equal(expectedIndex, actualIndex);
    }

    private delegate int FlatArrayEnumeratorIndexGetter<T>(in FlatArray<T>.Enumerator source);

    private delegate ReadOnlySpan<T> FlatArrayEnumeratorItemsGetter<T>(in FlatArray<T>.Enumerator source);

    private static FlatArrayEnumeratorItemsGetter<T> GetFlatArrayEnumeratorItemsGetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var fieldInfo = type.GetInnerFieldInfoOrThrow("items");

        var method = new DynamicMethod("GetInnerItems", typeof(ReadOnlySpan<T>), new[] { type.MakeByRefType() }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayEnumeratorItemsGetter<T>)method.CreateDelegate(typeof(FlatArrayEnumeratorItemsGetter<>).MakeGenericType(typeof(T)));
    }

    private static FlatArrayEnumeratorIndexGetter<T> GetFlatArrayEnumeratorIndexGetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var fieldInfo = type.GetInnerFieldInfoOrThrow("index");

        var method = new DynamicMethod("GetInnerIndex", typeof(int), new[] { type.MakeByRefType() }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayEnumeratorIndexGetter<T>)method.CreateDelegate(typeof(FlatArrayEnumeratorIndexGetter<>).MakeGenericType(typeof(T)));
    }
}