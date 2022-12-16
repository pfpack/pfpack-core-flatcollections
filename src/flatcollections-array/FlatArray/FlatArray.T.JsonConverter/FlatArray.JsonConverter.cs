using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial struct FlatArray<T>
{
    internal sealed partial class JsonConverter : JsonConverter<FlatArray<T>>
    {
        private readonly JsonConverter<T> itemConverter;

        public JsonConverter(JsonSerializerOptions options)
        {
            Debug.Assert(options is not null);

            itemConverter = (JsonConverter<T>)options.GetConverter(InnerItemType.Value);

            Debug.Assert(itemConverter is not null);
        }

        private static class InnerItemType
        {
            internal static readonly Type Value = typeof(T);
        }
    }
}
