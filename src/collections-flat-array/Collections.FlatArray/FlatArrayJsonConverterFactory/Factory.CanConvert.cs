using System.Diagnostics;

namespace System.Collections.Generic;

partial class FlatArrayJsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        // Internal implementation: the param is expected to be not null by the convention
        Debug.Assert(typeToConvert is not null);

        return
            typeToConvert.IsGenericType &&
            typeToConvert.GetGenericTypeDefinition() == typeof(FlatArray<>);
    }
}
