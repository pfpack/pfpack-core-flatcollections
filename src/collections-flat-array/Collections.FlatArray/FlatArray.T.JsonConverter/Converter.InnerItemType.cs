namespace System.Collections.Generic;

partial class FlatArrayJsonConverter<T>
{
    private static class InnerItemType
    {
        internal static readonly Type Value = typeof(T);
    }
}
