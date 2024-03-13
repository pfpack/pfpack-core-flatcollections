using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] List<T> source)
        =>
        source is null ? default : InnerFactoryHelper.FromList(source);

    // TODO: Add the tests and make public
    internal static FlatArray<T> From([AllowNull] List<T> source, int start, int length)
        =>
        InnerFactoryHelper.FromListValidated(source, start, length);
}
