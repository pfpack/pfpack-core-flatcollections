﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<T> ToFlatArray<T>([AllowNull] this IEnumerable<T> source)
        =>
        FlatArray<T>.From(source);
}
