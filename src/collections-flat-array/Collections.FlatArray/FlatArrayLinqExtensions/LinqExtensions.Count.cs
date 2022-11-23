using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static int Count<T>(this FlatArray<T> source)
        =>
        source.Length;
}
