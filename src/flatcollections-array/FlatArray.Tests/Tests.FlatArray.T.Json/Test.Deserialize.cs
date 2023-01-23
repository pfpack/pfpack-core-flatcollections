using System;
using System.Text.Json;
using Xunit;
using static PrimeFuncPack.Core.Tests.JsonSerializerTestSource;
using static PrimeFuncPack.UnitTest.TestData;

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
    public void Deserialize_SourceArrayIsNotEmpty_OptionsCases_ExpectInnerItemsAreEqualToSourceArrayItems(
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

    [Theory]
    //[InlineData(null)]
    [InlineData(AnotherString)]
    [InlineData("01")]
    [InlineData("01", "02")]
    [InlineData("01", "02", "03")]
    [InlineData("01", "02", "03", "04")]
    [InlineData("01", "02", "03", "04", "05")]
    [InlineData("01", "02", "03", "04", "05", "06")]
    [InlineData("01", "02", "03", "04", "05", "06", "07")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16")]
    [InlineData("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17")]
    public void Deserialize_SourceArrayIsNotEmpty_ExpectInnerItemsAreEqualToSourceArrayItems(
        params string?[] sourceItems)
    {
        var copied = sourceItems.GetCopy();

        var source = JsonSerializer.Serialize(sourceItems);
        var actual = JsonSerializer.Deserialize<FlatArray<string?>>(source);

        actual.VerifyInnerState(copied, copied.Length);
    }
}