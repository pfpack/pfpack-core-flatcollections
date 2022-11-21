using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T> itemConverter;

    internal FlatArrayJsonConverter([AllowNull] JsonSerializerOptions options)
    {
        // Null check for the sake of clarity:
        // the param is expected to be not null by the convention
        options ??= InnerGetOptionsDefault();

        itemConverter = (JsonConverter<T>)options.GetConverter(InnerItemType.Value);
    }
}
