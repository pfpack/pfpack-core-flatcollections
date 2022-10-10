using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T>? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            if (itemConverter is not null)
            {
                itemConverter.Write(writer, value.InternalItem(i), options);
            }
            else
            {
                JsonSerializer.Serialize(writer, value.InternalItem(i), options);
            }
        }

        writer.WriteEndArray();
    }
}