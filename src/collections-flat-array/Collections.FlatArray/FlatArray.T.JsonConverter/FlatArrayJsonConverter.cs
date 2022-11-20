using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonSerializerOptions? options;

    public FlatArrayJsonConverter([AllowNull] JsonSerializerOptions options)
        =>
        this.options = options;

    private JsonSerializerOptions? InnerSelectOptions([AllowNull] JsonSerializerOptions other)
        =>
        options ?? other;
}
