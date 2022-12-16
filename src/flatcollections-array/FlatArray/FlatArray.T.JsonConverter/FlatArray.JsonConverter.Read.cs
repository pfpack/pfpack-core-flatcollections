#define TRIM_EXCESS_ON_DESERIALIZATION

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
                throw new JsonException("The last processed JSON token is not the start of an array.");
            }

            const int DefaultCapacity = 4;

            int actualCount = default;
            var array = new T[DefaultCapacity];

            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.EndArray)
                {
                    if (actualCount == default)
                    {
                        return default;
                    }

#if TRIM_EXCESS_ON_DESERIALIZATION
                    if (actualCount < array.Length)
                    {
                        InnerArrayHelper.TruncateUnchecked(ref array, actualCount);
                    }

                    return new(array, default);
#else
                    return new(actualCount, array);
#endif
                }

                var item = itemConverter.Read(ref reader, InnerItemType.Value, options);

                if (actualCount < array.Length)
                {
                    array[actualCount++] = item!;
                }
                else if (actualCount < Array.MaxLength)
                {
                    int newCapacity = InnerAllocHelper.EstimateCapacity(array.Length, Array.MaxLength);
                    InnerArrayHelper.ExtendUnchecked(ref array, newCapacity);
                    array[actualCount++] = item!;
                }
                else
                {
                    throw InnerExceptionFactory.SourceTooLarge();
                }
            }

            throw new JsonException("Reading the JSON completed, but the end of the array was not found.");
        }
    }
}
