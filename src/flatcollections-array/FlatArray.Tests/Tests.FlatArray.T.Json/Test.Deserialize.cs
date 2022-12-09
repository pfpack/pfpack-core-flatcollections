using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using static PrimeFuncPack.Collections.Tests.JsonSerializerTestSource;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Deserialize_SourceIsNullJsonValue_ExpectDefaultState(
        JsonSerializerOptions? options)
    {
        var source = "null";
        var actual = JsonSerializer.Deserialize<FlatArray<StubItemJson>>(source, options);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Deserialize_SourceArrayIsEmpty_ExpectDefaultState(
        JsonSerializerOptions? options)
    {
        var sourceArray = Array.Empty<StubItemJson?>();
        var source = JsonSerializer.Serialize(sourceArray, options);

        var actual = JsonSerializer.Deserialize<FlatArray<StubItemJson?>>(source, options);
        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Deserialize_SourceArrayIsNotEmpty_ExpectInnerItemsAreEqualToSourceArrayItems(
        JsonSerializerOptions? options)
    {
        var sourceArray = new StubItemJson?[]
        {
            null,
            new()
            {
                Id = 1,
                Name = "First",
                EnumValue = StubEnum.Default,
                Date = new(2019, 05, 10, 07, 15, 21, TimeSpan.FromHours(3))
            },
            new()
            {
                Id = int.MaxValue,
                EnumText = StubEnum.Default
            },
            new()
            {
                Id = 4,
                Name = "Four",
                EnumText = StubEnum.Default,
                EnumValue = StubEnum.Some
            }
        };

        var source = JsonSerializer.Serialize(sourceArray, options);
        var actual = JsonSerializer.Deserialize<FlatArray<StubItemJson?>>(source, options);

        var expectedItems = new StubItemJson?[]
        {
            null,
            new()
            {
                Id = 1,
                Name = "First",
                EnumValue = StubEnum.Default,
                Date = new(2019, 05, 10, 07, 15, 21, TimeSpan.FromHours(3))
            },
            new()
            {
                Id = int.MaxValue,
                EnumText = StubEnum.Default
            },
            new()
            {
                Id = 4,
                Name = "Four",
                EnumText = StubEnum.Default,
                EnumValue = StubEnum.Some
            }
        };

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}