namespace System;

partial class FlatArrayJsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        =>
        typeToConvert.IsGenericType &&
        typeToConvert.GetGenericTypeDefinition() == typeof(FlatArray<>);
}
