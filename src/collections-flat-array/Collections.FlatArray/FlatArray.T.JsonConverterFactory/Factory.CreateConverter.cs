using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        // The internal implementation: the params are expected to be not null
        Debug.Assert(typeToConvert is not null);
        Debug.Assert(options is not null);

        Debug.Assert(CanConvert(typeToConvert));

        var itemType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter?)Activator.CreateInstance(
            type: typeof(FlatArrayJsonConverter<>).MakeGenericType(itemType),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object?[] { options },
            culture: null);

        // CreateInstance returns null only for the Nullable<T> instances with no value
        Debug.Assert(converter is not null);

        return converter;
    }
}
