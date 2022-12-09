using System.Diagnostics;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        Debug.Assert(typeToConvert is not null);

        return
            typeToConvert.IsGenericType &&
            typeToConvert.GetGenericTypeDefinition() == typeof(FlatArray<>);
    }
}
