using System.Text.Json;

namespace System.Collections.Immutable;

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

        foreach (var item in value)
        {
            if (itemConverter is not null)
            {
                itemConverter.Write(writer, item, options);
            }
            else
            {
                JsonSerializer.Serialize(writer, item, options);
            }
        }

        writer.WriteEndArray();
    }
}