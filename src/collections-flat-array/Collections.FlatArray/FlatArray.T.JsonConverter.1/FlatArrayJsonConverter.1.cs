using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter1<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T> itemConverter;

    public FlatArrayJsonConverter1([AllowNull] JsonSerializerOptions options)
        =>
#if NET7_0_OR_GREATER
        itemConverter = InnerBuildItemConverter(options ?? JsonSerializerOptions.Default);
#else
        itemConverter = InnerBuildItemConverter(options ?? InnerJsonSerializerOptionsDefault.Value);
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static JsonConverter<T> InnerBuildItemConverter(JsonSerializerOptions options)
        =>
        (JsonConverter<T>)options.GetConverter(InnerItemType.Value);

    private static class InnerItemType
    {
        internal static readonly Type Value = typeof(T);
    }

#if !NET7_0_OR_GREATER
    private static class InnerJsonSerializerOptionsDefault
    {
        internal static readonly JsonSerializerOptions Value = new(JsonSerializerDefaults.General);
    }
#endif
}
