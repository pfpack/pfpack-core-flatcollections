using System.Diagnostics;
using System.Text.Json;

namespace System;

partial struct FlatArray<T>
{
    partial class JsonConverter
    {
        public override FlatArray<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(reader.TokenType is not JsonTokenType.None);
            Debug.Assert(options is not null);

            if (reader.TokenType is JsonTokenType.Null)
            {
                return default;
            }

            if (reader.TokenType is not JsonTokenType.StartArray)
            {
                throw InnerJsonExceptionFactory.JsonTokenNotStartArray();
            }

            if (InnerReadNextToken(ref reader) is JsonTokenType.EndArray)
            {
                return default;
            }

            var array = new T[InnerAllocHelper.DefaultPositiveCapacity];
            array[0] = InnerReadItem(ref reader, options);
            int actualCount = 1;

            while (InnerReadNextToken(ref reader) is not JsonTokenType.EndArray)
            {
                if (actualCount == array.Length)
                {
                    InnerBufferHelper.GrowBuffer(ref array);
                }

                array[actualCount++] = InnerReadItem(ref reader, options);
            }

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }

        private static JsonTokenType InnerReadNextToken(ref Utf8JsonReader reader)
            =>
            reader.Read() ? reader.TokenType : throw InnerJsonExceptionFactory.JsonReadCompletedNoEndArray();

        private T InnerReadItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
            =>
            itemConverter.Read(ref reader, InnerItemType.Value, options)!;
    }
}
