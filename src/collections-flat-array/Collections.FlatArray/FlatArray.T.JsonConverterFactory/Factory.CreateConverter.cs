#define USE_CONVERTER_V1
//#define USE_CONVERTER_V2
//#define USE_CONVERTER_V3
//#define USE_CONVERTER_V2_1
//#define USE_CONVERTER_V3_1

using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(CanConvert(typeToConvert));

        _ = typeToConvert ?? throw new ArgumentNullException(nameof(typeToConvert));

        var itemType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter?)Activator.CreateInstance(
            type: InnerJsonConverterType.MakeGenericType(itemType),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: InnerBuildArgs(options),
            culture: null);

        Debug.Assert(converter is not null);

        return converter;
    }

#if USE_CONVERTER_V1
    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter<>);

    private static object?[]? InnerBuildArgs(JsonSerializerOptions options) => new object?[] { options };
#elif USE_CONVERTER_V2
    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter2<>);

    private static object?[]? InnerBuildArgs(JsonSerializerOptions options) => new object?[] { options };
#elif USE_CONVERTER_V3
    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter3<>);

    private static object?[]? InnerBuildArgs(JsonSerializerOptions options) => new object?[] { options };
#elif USE_CONVERTER_V2_1
    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter21<>);

#pragma warning disable IDE0060 // Remove unused parameter
    private static object?[]? InnerBuildArgs(JsonSerializerOptions options) => null;
#pragma warning restore IDE0060 // Remove unused parameter
#elif USE_CONVERTER_V3_1
    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter31<>);

#pragma warning disable IDE0060 // Remove unused parameter
    private static object?[]? InnerBuildArgs(JsonSerializerOptions options) => null;
#pragma warning restore IDE0060 // Remove unused parameter
#endif
}
