using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T> itemConverter;

    internal FlatArrayJsonConverter([AllowNull] JsonSerializerOptions options)
    {
        options ??= InnerGetOptionsDefault();

        itemConverter = (JsonConverter<T>)options.GetConverter(InnerItemType.Value);
    }

    private static class InnerItemType
    {
        internal static readonly Type Value = typeof(T);
    }
}
