using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        // Looks simpler but performs copying the array
        //JsonSerializer.Serialize(writer, value.ToArray(), InnerSelectOptions(options));

        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            JsonSerializer.Serialize(writer, value.InternalItem(i), InnerSelectOptions(options));
        }

        writer.WriteEndArray();
    }
}
