using System.Diagnostics;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

//[JsonConverter(typeof(FlatArrayJsonConverterFactory))]
[DebuggerDisplay("Length = {Length}")]
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

    [Obsolete("This property is not intended for use. Read Length property instead.", error: true)]
    public int Count
        =>
        items.Length;

    public bool IsNotEmpty
        =>
        items.Length > 0;

    public bool IsEmpty
        =>
        items.Length is not > 0;
}
