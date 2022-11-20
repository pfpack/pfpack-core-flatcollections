using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter31<T>
{
    public override FlatArray<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null)
        {
            return default;
        }

        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException("The last processed JSON token is not the start of an array.");
        }

        var arr = JsonSerializer.Deserialize<T[]>(ref reader, options);

        return arr is null ? default : new(arr);
    }
}
