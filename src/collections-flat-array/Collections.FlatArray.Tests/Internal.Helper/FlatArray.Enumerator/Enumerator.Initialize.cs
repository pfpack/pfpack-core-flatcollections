using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Enumerator InitializeFlatArrayEnumerator<T>(this T[] items, int index)
    {
        var source = default(FlatArray<T>.Enumerator);

        GetFlatArrayEnumeratorItemsSetter<T>().Invoke(source, new(items));
        GetFlatArrayEnumeratorIndexSetter<T>().Invoke(source, index);

        return source;
    }

    private delegate void FlatArrayEnumeratorItemsSetter<T>(in FlatArray<T>.Enumerator source, ReadOnlySpan<T> items);

    private delegate void FlatArrayEnumeratorIndexSetter<T>(in FlatArray<T>.Enumerator source, int index);

    private static FlatArrayEnumeratorItemsSetter<T> GetFlatArrayEnumeratorItemsSetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var fieldInfo = type.GetInnerFieldInfoOrThrow("items");

        var method = new DynamicMethod("SetInnerItems", typeof(void), new[] { type.MakeByRefType(), typeof(ReadOnlySpan<T>) }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayEnumeratorItemsSetter<T>)method.CreateDelegate(typeof(FlatArrayEnumeratorItemsSetter<>).MakeGenericType(typeof(T)));
    }

    private static FlatArrayEnumeratorIndexSetter<T> GetFlatArrayEnumeratorIndexSetter<T>()
    {
        var type = typeof(FlatArray<T>.Enumerator);
        var fieldInfo = type.GetInnerFieldInfoOrThrow("index");

        var method = new DynamicMethod("SetInnerIndex", typeof(void), new[] { type.MakeByRefType(), typeof(int) }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (FlatArrayEnumeratorIndexSetter<T>)method.CreateDelegate(typeof(FlatArrayEnumeratorIndexSetter<>).MakeGenericType(typeof(T)));
    }
}