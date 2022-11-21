using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    private static JsonSerializerOptions InnerOptionsDefault
        =>
#if NET7_0_OR_GREATER
        JsonSerializerOptions.Default;
#else
        InnerJsonSerializerOptionsDefault.Value;

    private static class InnerJsonSerializerOptionsDefault
    {
        internal static readonly JsonSerializerOptions Value = new();
    }
#endif
}
