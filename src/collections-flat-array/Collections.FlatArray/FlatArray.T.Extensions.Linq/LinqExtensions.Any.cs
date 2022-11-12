using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static bool Any<T>(this FlatArray<T> source)
        =>
        source.IsNotEmpty;
}
