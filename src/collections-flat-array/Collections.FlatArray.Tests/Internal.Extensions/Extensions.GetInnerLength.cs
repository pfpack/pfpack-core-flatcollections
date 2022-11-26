using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.FlatArray.Tests;

partial class TestExtensions
{
    internal static int GetInnerLength<T>(this FlatArray<T> array)
    {
        var length = typeof(FlatArray<T>).GetInnerFieldInfoOrThrow("length").GetValue(array);
        
        if (length is null)
        {
            throw new InvalidOperationException("An enexpected inner length value: null");
        }

        return (int)length;
    }
}