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

            if (reader.Read() is not true)
            {
                throw InnerJsonExceptionFactory.JsonReadCompletedNoEndArray();
            }

            if (reader.TokenType is JsonTokenType.EndArray)
            {
                return default;
            }

            var array = new T[InnerAllocHelper.DefaultPositiveCapacity];
            int actualCount = 0;

            do
            {
                if (actualCount == array.Length)
                {
                    int newCapacity = array.Length < Array.MaxLength
                        ? InnerAllocHelper.IncreaseCapacity(array.Length, Array.MaxLength)
                        : throw InnerExceptionFactory.SourceTooLarge();

                    InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
                }

                array[actualCount++] = itemConverter.Read(ref reader, InnerItemType.Value, options)!;

                if (reader.Read() is not true)
                {
                    throw InnerJsonExceptionFactory.JsonReadCompletedNoEndArray();
                }
            }
            while (reader.TokenType is not JsonTokenType.EndArray);

            if (actualCount < array.Length)
            {
                InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
            }

            return new(array, default);
        }
    }
}
