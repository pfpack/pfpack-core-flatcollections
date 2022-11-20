using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter21<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        _ = writer ?? throw new ArgumentNullException(nameof(writer));

        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            JsonSerializer.Serialize(writer, value.InternalItem(i), options);
        }

        writer.WriteEndArray();
    }
}
