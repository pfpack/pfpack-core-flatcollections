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
            args: new object?[] { options },
            culture: null);

        // The result is expected to be not null:
        // CreateInstance returns null only for the Nullable<T> instances with no value
        Debug.Assert(converter is not null);

        return converter;
    }

    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter<>);
}
