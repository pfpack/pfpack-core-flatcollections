using System.Collections.Generic;

namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static T ElementAt<T>(this FlatArray<T> source, int index)
        =>
        source[index]; // Delegate index checking to the indexer

    public static T ElementAt<T>(this FlatArray<T> source, Index index)
        =>
        source[index]; // Delegate index checking to the indexer
}
