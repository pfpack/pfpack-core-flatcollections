using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial struct FlatArray<T>
{
    internal sealed partial class JsonConverter : JsonConverter<FlatArray<T>>
    {
        private readonly JsonConverter<T> itemConverter;

        internal JsonConverter(JsonSerializerOptions options)
            =>
            itemConverter = (JsonConverter<T>)options.GetConverter(InnerItemType.Value);

        private static class InnerItemType
        {
            internal static readonly Type Value = typeof(T);
        }
    }
}
