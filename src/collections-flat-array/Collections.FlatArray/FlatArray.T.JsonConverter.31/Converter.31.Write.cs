using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter31<T>
{
    public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
    {
        _ = writer ?? throw new ArgumentNullException(nameof(writer));

        JsonSerializer.Serialize(writer, value.ToArray(), options);
    }
}
