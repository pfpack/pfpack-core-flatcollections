using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Immutable;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var itemType = typeToConvert.GetGenericArguments()[0];

        return (JsonConverter?)Activator.CreateInstance(
            type: typeof(FlatArrayJsonConverter<>).MakeGenericType(new[] { itemType }),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { options },
            culture: null);
    }
}