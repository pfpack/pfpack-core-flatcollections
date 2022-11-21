using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static JsonSerializerOptions InnerGetOptionsDefault()
        =>
#if NET7_0_OR_GREATER
        JsonSerializerOptions.Default;
#else
        new();
#endif
}
