using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        // Null check for the sake of clarity:
        // the params are expected to be not null by the convention
        _ = writer ?? throw new ArgumentNullException(nameof(writer));
        options ??= InnerGetOptionsDefault();

        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            itemConverter.Write(writer, value.InternalItem(i), options);
        }

        writer.WriteEndArray();
    }
}
