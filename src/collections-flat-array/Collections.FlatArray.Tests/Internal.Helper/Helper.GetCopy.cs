using System;

namespace PrimeFuncPack.Collections.Tests;

partial class TestHelper
{
    internal static T[] GetCopy<T>(this T[] source)
    {
        if (source.Length is 0)
        {
            return Array.Empty<T>();
        }

        var copy = new T[source.Length];
        Array.Copy(source, copy, source.Length);

        return copy;
    }
}