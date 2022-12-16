using System.Diagnostics;
using System.Text.Json;

namespace System;

partial class FlatArrayJsonConverter<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        Debug.Assert(writer is not null);
        Debug.Assert(options is not null);

        writer.WriteStartArray();
        value.InternalForEach(InnerWriteItem);
        writer.WriteEndArray();

        void InnerWriteItem(T item) => itemConverter.Write(writer, item, options);
    }
}
