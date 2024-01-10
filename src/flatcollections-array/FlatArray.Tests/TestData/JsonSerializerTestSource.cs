using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

internal static class JsonSerializerTestSource
{
    public static TheoryData<JsonSerializerOptions?> JsonSerializerOptionsTestData
        =>
        new()
        {
            {
                null
            },
            {
                new JsonSerializerOptions()
            },
            {
                new JsonSerializerOptions(JsonSerializerDefaults.General)
            },
            {
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            },
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