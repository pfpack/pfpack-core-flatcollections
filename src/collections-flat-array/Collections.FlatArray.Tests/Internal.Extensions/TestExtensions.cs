using System;
using System.Reflection;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

internal static partial class TestExtensions
{
    private static FieldInfo GetInnerFieldInfoOrThrow(this Type type, string fieldName)
        =>
        type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException($"An inner field '{fieldName}' of the type {type} was not found");
}