using System;
using System.Reflection;
using System.Reflection.Emit;

namespace PrimeFuncPack.Core.Tests;

internal static partial class TestHelper
{
    private static T GetStructFieldValue<T>(this object source, string fieldName)
        where T : struct
        =>
        source.GetType().GetInnerFieldInfoOrThrow(fieldName).GetValue(source) switch
        {
            T fieldValue => fieldValue,
            var unexpected => throw new InvalidOperationException($"An unexpected field '{fieldName}' value: {unexpected}")
        };

    private static T? GetFieldValue<T>(this object source, string fieldName)
        =>
        (T?)source.GetType().GetInnerFieldInfoOrThrow(fieldName).GetValue(source);

    private static void SetFieldValue<T>(this object source, string fieldName, T fieldValue)
        =>
        source.GetType().GetInnerFieldInfoOrThrow(fieldName).SetValue(source, fieldValue);

    private static FieldInfo GetInnerFieldInfoOrThrow(this Type type, string fieldName)
        =>
        type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)
        ?? throw new InvalidOperationException($"An inner field '{fieldName}' of the FlatArray<T> type was not found");

    private static TDelegate CreateGetter<TDelegate>(this Type ownerType, string fieldName)
        where TDelegate : Delegate
    {
        var fieldInfo = ownerType.GetInnerFieldInfoOrThrow(fieldName);
        var methodName = "GetInner" + fieldName;

        var method = new DynamicMethod(methodName, fieldInfo.FieldType, new[] { ownerType.MakeByRefType() }, ownerType, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (TDelegate)method.CreateDelegate(typeof(TDelegate));
    }

    private static TDelegate CreateSetter<TDelegate>(this Type ownerType, string fieldName)
        where TDelegate : Delegate
    {
        var fieldInfo = ownerType.GetInnerFieldInfoOrThrow(fieldName);
        var methodName = "SetInner" + fieldName;

        var method = new DynamicMethod(methodName, typeof(void), new[] { ownerType.MakeByRefType(), fieldInfo.FieldType }, ownerType, true);
        var ilGenerator = method.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
        ilGenerator.Emit(OpCodes.Ret);

        return (TDelegate)method.CreateDelegate(typeof(TDelegate));
    }
}