using System;
using System.Text.Json.Serialization;

namespace PrimeFuncPack.Core.Tests;

internal sealed record class StubItemJson
{
    public int Id { get; init; }

    public string? Name { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    public StubEnum? EnumValue { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StubEnum? EnumText { get; init; }

    [JsonIgnore]
    public long HiddenValue { get; init; }
}