using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T>? itemConverter;

    private readonly Type itemType;

    public FlatArrayJsonConverter([AllowNull] JsonSerializerOptions options)
    {
        itemType = typeof(T);
        itemConverter = (JsonConverter<T>?)options?.GetConverter(itemType);
    }
}