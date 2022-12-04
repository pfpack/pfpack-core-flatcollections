using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder InitializeFlatArrayBuilder<T>(this T[] items, int index)
    {
        var source = default(FlatArray<T>.Builder);

        GetFlatArrayBuilderItemsSetter<T>().Invoke(source, new(items));
        GetFlatArrayBuilderIndexSetter<T>().Invoke(source, index);

        return source;
    }

    private delegate void FlatArrayBuilderItemsSetter<T>(in FlatArray<T>.Builder source, ReadOnlySpan<T> items);

    private delegate void FlatArrayBuilderIndexSetter<T>(in FlatArray<T>.Builder source, int index);

    private static FlatArrayBuilderItemsSetter<T> GetFlatArrayBuilderItemsSetter<T>()
    {
        var type = typeof(FlatArray<T>.Builder);
        var fieldInfo = typeof(FlatArray<T>.Builder).GetInnerFieldInfoOrThrow("items");

        var method = new DynamicMethod("SetInnerItems", typeof(void), new[] { type.MakeByRefType(), typeof(ReadOnlySpan<T>) }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayBuilderItemsSetter<T>)method.CreateDelegate(typeof(FlatArrayBuilderItemsSetter<>).MakeGenericType(typeof(T)));
    }

    private static FlatArrayBuilderIndexSetter<T> GetFlatArrayBuilderIndexSetter<T>()
    {
        var type = typeof(FlatArray<T>.Builder);
        var fieldInfo = typeof(FlatArray<T>.Builder).GetInnerFieldInfoOrThrow("index");

        var method = new DynamicMethod("SetInnerIndex", typeof(void), new[] { type.MakeByRefType(), typeof(int) }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayBuilderIndexSetter<T>)method.CreateDelegate(typeof(FlatArrayBuilderIndexSetter<>).MakeGenericType(typeof(T)));
    }
}