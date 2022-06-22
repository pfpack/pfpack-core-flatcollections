using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override FlatArray<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null)
        {
            return null;
        }

        if (itemConverter is null)
        {
            var arr = JsonSerializer.Deserialize<T[]>(ref reader, options);
            return arr is null ? null : new(arr); // or use FlatArray<T>.From(arr) to get the Empty on zero length
        }

        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        var list = new List<T>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                return new(list.ToArray()); // or use FlatArray<T>.From(list) to get the Empty on zero length
            }

            var item = itemConverter.Read(ref reader, itemType, options);
            list.Add(item!);
        }

        throw new JsonException();
    }
}