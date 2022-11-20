using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class AlternateFlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private static Type ItemType => typeof(T);

    private readonly JsonConverter<T>? itemConverter;

    public AlternateFlatArrayJsonConverter([AllowNull] JsonSerializerOptions options)
    {
        if (options is not null)
        {
            itemConverter = (JsonConverter<T>)options.GetConverter(ItemType);
        }
    }
}
