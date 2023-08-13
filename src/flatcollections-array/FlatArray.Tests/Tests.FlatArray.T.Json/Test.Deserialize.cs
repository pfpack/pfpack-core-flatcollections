using PrimeFuncPack.Core.Tests.TestData;
using System;
using System.Text.Json;
using Xunit;
using static PrimeFuncPack.Core.Tests.JsonSerializerTestSource;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Deserialize_SourceIsNullJsonValue_ExpectDefaultState(
        JsonSerializerOptions? options)
    {
        const string source = "null";
        var actual = JsonSerializer.Deserialize<FlatArray<StubItemJson>>(source, options);

        actual.VerifyInnerState(default, default);
    }

    [Theory]
    [MemberData(nameof(GetJsonSerializerOptionsTestData), MemberType = typeof(JsonSerializerTestSource))]
    public void Deserialize_SourceArrayIsEmpty_ExpectDefaultState(
        JsonSerializerOptions? options)
    {
        const string source = "[]";
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
    [MemberData(nameof(ReadingCollectionsTestSource.EnumerateStringNonEmptyCases), MemberType = typeof(ReadingCollectionsTestSource))]
    public void Deserialize_SourceArrayIsNotEmpty_Strings_ExpectInnerStateCorrespondsToSource(
        string?[] sourceItems, string?[] expectedItems)
    {
        var source = JsonSerializer.Serialize(sourceItems);
        var actual = JsonSerializer.Deserialize<FlatArray<string?>>(source);

        actual.VerifyInnerState(expectedItems, sourceItems.Length);
    }

    [Theory]
    [MemberData(nameof(ReadingCollectionsTestSource.EnumerateInt32NullableNonEmptyCases), MemberType = typeof(ReadingCollectionsTestSource))]
    public void Deserialize_SourceArrayIsNotEmpty_Int32Nullable_ExpectInnerStateCorrespondsToSource(
        int?[] sourceItems, int?[] expectedItems)
    {
        var source = JsonSerializer.Serialize(sourceItems);
        var actual = JsonSerializer.Deserialize<FlatArray<int?>>(source);

        actual.VerifyInnerState(expectedItems, sourceItems.Length);
    }
}