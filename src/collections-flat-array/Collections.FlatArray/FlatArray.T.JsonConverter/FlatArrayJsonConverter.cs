using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T> itemConverter;

    public FlatArrayJsonConverter(JsonSerializerOptions? options)
        =>
        itemConverter = InnerBuildItemConverter(options ?? InnerOptionsDefault);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static JsonConverter<T> InnerBuildItemConverter(JsonSerializerOptions options)
        =>
        (JsonConverter<T>)options.GetConverter(InnerItemType.Value);

    private static class InnerItemType
    {
        internal static readonly Type Value = typeof(T);
    }
}
