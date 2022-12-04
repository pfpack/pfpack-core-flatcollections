using System.Collections.Generic;
using System.Reflection.Emit;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static FlatArray<T>.Builder InitializeFlatArrayBuilder<T>(this T[] items, int? length = null)
    {
        var source = default(FlatArray<T>.Builder);

        GetFlatArrayBuilderFieldSetter<T, T[]>("items").Invoke(source, items);
        GetFlatArrayBuilderFieldSetter<T, int>("length").Invoke(source, length ?? items.Length);

        return source;
    }

    private delegate void FlatArrayBuilderFieldSetter<T, TValue>(in FlatArray<T>.Builder source, TValue value);

    private static FlatArrayBuilderFieldSetter<T, TValue> GetFlatArrayBuilderFieldSetter<T, TValue>(string fieldName)
    {
        var type = typeof(FlatArray<T>.Builder);
        var fieldInfo = type.GetInnerFieldInfoOrThrow(fieldName);

        var method = new DynamicMethod("SetInnerValue", typeof(void), new[] { type.MakeByRefType(), typeof(TValue) }, type, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        var setter = method.CreateDelegate(typeof(FlatArrayBuilderFieldSetter<,>).MakeGenericType(typeof(T), typeof(TValue)));
        return (FlatArrayBuilderFieldSetter<T, TValue>)setter;
    }
}