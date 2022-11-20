using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter2<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            JsonSerializer.Serialize(writer, value.InternalItem(i), this.options ?? options);
        }

        writer.WriteEndArray();
    }
}
