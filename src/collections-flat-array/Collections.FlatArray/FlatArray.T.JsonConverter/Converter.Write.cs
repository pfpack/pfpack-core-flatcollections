using System.Diagnostics;
using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        // The internal implementation: the params are expected to be not null
        Debug.Assert(writer is not null);
        Debug.Assert(options is not null);

        writer.WriteStartArray();

        for (int i = 0; i < value.Length; i++)
        {
            itemConverter.Write(writer, value.InternalItem(i), options);
        }

        writer.WriteEndArray();
    }
}
