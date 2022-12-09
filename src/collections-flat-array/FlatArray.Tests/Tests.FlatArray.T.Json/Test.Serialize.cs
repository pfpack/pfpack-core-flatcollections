using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using static PrimeFuncPack.Collections.Tests.JsonSerializerTestSource;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Serialize_SourceIsDefault_ExpectJsonIsEqualToEmptyArrayJson(
        JsonSerializerOptions? options)
    {
        var source = default(FlatArray<StubItemJson?>);
        var actual = JsonSerializer.Serialize(source, options);

        var expectedArray = Array.Empty<StubItemJson?>();
        var expected = JsonSerializer.Serialize(expectedArray, options);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Serialize_SourceIsNotDefault_ExpectJsonIsEqualToArrayJson(
        JsonSerializerOptions? options)
    {
        var sourceItems = new StubItemJson?[]
        {
            new()
            {
                Id = 1,
                Name = "First",
                EnumValue = StubEnum.Some,
                Date = new(2022, 11, 01, 23, 51, 45, default),
                HiddenValue = 157
            },
            null,
            new()
            {
                Id = -3,
                EnumText = StubEnum.Some,
                EnumValue = StubEnum.Default
            },
            new()
            {
                Id = 4,
                Name = "Four"
            }
        };

        var source = sourceItems.InitializeFlatArray(3);
        var actual = JsonSerializer.Serialize(source, options);

        var expectedArray = new StubItemJson?[]
        {
            new()
            {
                Id = 1,
                Name = "First",
                EnumValue = StubEnum.Some,
                Date = new(2022, 11, 01, 23, 51, 45, default)
            },
            null,
            new()
            {
                Id = -3,
                EnumText = StubEnum.Some,
                EnumValue = StubEnum.Default
            }
        };

        var expected = JsonSerializer.Serialize(expectedArray, options);

        Assert.Equal(expected, actual);
    }
}