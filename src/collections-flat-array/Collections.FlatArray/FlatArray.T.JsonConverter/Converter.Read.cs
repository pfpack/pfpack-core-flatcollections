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

            // Or use FlatArray<T>.From(arr) to get the Empty on zero length
            return arr is null ? null : new(arr);
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
                // Or use FlatArray<T>.From(list) / FlatArray<T>.From(list.ToArray()) to get the Empty on zero length
                return new(list.ToArray());
            }

            var item = itemConverter.Read(ref reader, itemType, options);
            list.Add(item!);
        }

        throw new JsonException();
    }
}