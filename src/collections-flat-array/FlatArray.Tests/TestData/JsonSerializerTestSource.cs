using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PrimeFuncPack.Core.Tests;

internal static class JsonSerializerTestSource
{
    public static IEnumerable<object?[]> GetJsonSerializerOptionsTestData()
        =>
        new[]
        {
            new object?[]
            {
                null
            },
            new object?[]
            {
                new JsonSerializerOptions()
            },
            new object?[]
            {
                new JsonSerializerOptions(JsonSerializerDefaults.General)
            },
            new object?[]
            {
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            },
            new object?[]
            {
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    WriteIndented = true
                }
                .AddConverter(new JsonStringEnumConverter())
            }
        };

    private static JsonSerializerOptions AddConverter(this JsonSerializerOptions options, JsonConverter converter)
    {
        options.Converters.Add(converter);
        return options;
    }
}