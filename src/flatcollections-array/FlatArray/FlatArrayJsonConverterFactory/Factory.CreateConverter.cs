using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert is not null);
        Debug.Assert(options is not null);

        Debug.Assert(CanConvert(typeToConvert));

        var itemType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter?)Activator.CreateInstance(
            type: typeof(FlatArray<>.JsonConverter).MakeGenericType(itemType),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [options],
            culture: null);

        Debug.Assert(converter is not null);

        return converter;
    }
}
