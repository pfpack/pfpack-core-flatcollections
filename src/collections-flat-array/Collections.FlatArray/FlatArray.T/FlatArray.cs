using System.Text.Json.Serialization;

namespace System.Collections.Generic;

//[JsonConverter(typeof(FlatArrayJsonConverterFactory))]
public sealed partial class FlatArray<T> :
    IReadOnlyList<T>,
    IEquatable<FlatArray<T>>,
    ICloneable
{
    private readonly T[] items;

    public int Length
        =>
        items.Length;

    int IReadOnlyCollection<T>.Count
        =>
        items.Length;
}
