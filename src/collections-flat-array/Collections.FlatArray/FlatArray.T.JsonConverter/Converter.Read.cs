using System.Diagnostics;
using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override FlatArray<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Internal implementation: the param is expected to be not null by the convention
        Debug.Assert(options is not null);

        if (reader.TokenType is JsonTokenType.Null)
        {
            return default;
        }

        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException("The last processed JSON token is not the start of an array.");
        }

        var list = new List<T>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                return FlatArray<T>.From(list);
            }

            var item = itemConverter.Read(ref reader, InnerItemType.Value, options);
            list.Add(item!);
        }

        throw new JsonException("The JSON reading completed, but the end of the array was not found.");
    }
}
