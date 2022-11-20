using System.Text.Json;

namespace System.Collections.Generic;

partial class AlternateFlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            if (itemConverter is null)
            {
                JsonSerializer.Serialize(writer, value.InternalItem(i), options);
            }
            else
            {
                itemConverter.Write(writer, value.InternalItem(i), options);
            }
        }

        writer.WriteEndArray();
    }
}
