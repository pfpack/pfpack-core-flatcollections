using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter3<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonSerializerOptions? options;

    public FlatArrayJsonConverter3([AllowNull] JsonSerializerOptions options)
        =>
        this.options = options;
}
