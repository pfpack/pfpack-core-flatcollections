using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        _ = typeToConvert ?? throw new ArgumentNullException(nameof(typeToConvert));

        var itemType = typeToConvert.GetGenericArguments()[0];

        return (JsonConverter?)Activator.CreateInstance(
            type: InnerJsonConverterType.MakeGenericType(itemType),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { options },
            culture: null);
    }

    private static Type InnerJsonConverterType => typeof(FlatArrayJsonConverter<>);
}
