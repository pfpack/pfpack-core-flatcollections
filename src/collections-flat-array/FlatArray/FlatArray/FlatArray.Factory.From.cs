using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArray
{
    public static FlatArray<T> From<T>([AllowNull] params T[] source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>(FlatArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>(FlatArray<T>? source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>([AllowNull] List<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>(ImmutableArray<T> source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>(ImmutableArray<T>? source)
        =>
        FlatArray<T>.From(source);

    public static FlatArray<T> From<T>([AllowNull] IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
