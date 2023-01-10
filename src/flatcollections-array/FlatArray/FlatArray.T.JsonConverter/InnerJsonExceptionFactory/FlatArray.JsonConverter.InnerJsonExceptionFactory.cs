using System.Text.Json;

namespace System;

partial struct FlatArray<T>
{
    partial class JsonConverter
    {
        private static class InnerJsonExceptionFactory
        {
            internal static JsonException JsonTokenNotStartArray()
                =>
                new("The last processed JSON token is not the start of a JSON array.");

            internal static JsonException JsonReadCompletedNoEndArray()
                =>
                new("Reading the JSON completed, but the end of the JSON array was not found.");
        }
    }
}
