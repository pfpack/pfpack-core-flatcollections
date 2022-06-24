using System.Diagnostics.CodeAnalysis;
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

    [Obsolete("This property is not intended for use. Read Length property instead.", error: true)]
    public int Count
        =>
        items.Length;
}

public static class NotIntendedFlatArrayExtensions
{
    [Obsolete("This method is not intended for use. Read Length property instead.", error: true)]
    [DoesNotReturn]
    public static int Count<T>(this FlatArray<T> flatArray)
        =>
        throw new NotImplementedException();
}
