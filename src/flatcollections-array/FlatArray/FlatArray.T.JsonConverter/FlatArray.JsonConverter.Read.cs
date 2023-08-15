using System.Diagnostics;
using System.Runtime.CompilerServices;
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
            var actualCount = 1;

            while (InnerReadNextToken(ref reader) is not JsonTokenType.EndArray)
            {
                if (actualCount == array.Length)
                {
                    InnerBufferHelper.EnlargeBuffer(ref array);
                }

                array[actualCount++] = InnerReadItem(ref reader, options);
            }

            return new(actualCount, array);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonTokenType InnerReadNextToken(ref Utf8JsonReader reader)
            =>
            reader.Read() ? reader.TokenType : throw InnerJsonExceptionFactory.JsonReadCompletedNoEndArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InnerReadItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
            =>
            itemConverter.Read(ref reader, InnerItemType.Value, options)!;
    }
}
